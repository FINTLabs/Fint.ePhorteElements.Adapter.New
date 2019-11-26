using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using Fint.Sse.Adapter.Services.NCore;
using Gecko.NCore.Client;
using Gecko.NCore.Client.ObjectModel.V3.En;

namespace Fint.Sse.Adapter.Services
{
    public class EphorteElementsService : IEphorteElementsService
    {
        private static IEphorteContext EphorteContext { get; set; }

        public EphorteElementsService(NCoreFactory nCoreFactory)
        {
            EphorteContext = nCoreFactory.Create();
        }

        public Case GetCase(FintQuery query)
        {
            try
            {
                Expression<Func<Case, bool>> expression = null;

                if (query.IdType.Equals("systemid"))
                {
                    expression = c => c.Id == Convert.ToInt32(query.Id);
                }
                else if (query.IdType.Equals("mappeid"))
                {
                    var idParts = query.Id.Split('/');
                    var caseYear = Convert.ToInt32(idParts[0]);
                    var sequenceNumber = Convert.ToInt32(idParts[1]);

                    expression = c => c.CaseYear == caseYear && c.SequenceNumber == sequenceNumber;
                }

                var @case = EphorteContext.Query<Case>().FirstOrDefault(expression);

                return @case;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                
                return null;
            }
        }

        public IEnumerable<CaseStatus> GetCaseStatuses()
        {
            return EphorteContext.Query<CaseStatus>().ToList();
        }
    }
}
