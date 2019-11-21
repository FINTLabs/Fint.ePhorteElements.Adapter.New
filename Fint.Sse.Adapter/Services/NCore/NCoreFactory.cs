using System;
using Gecko.NCore.Client;
using Gecko.NCore.Client.Documents;
using Gecko.NCore.Client.Documents.V2;
using Gecko.NCore.Client.Functions;
using Gecko.NCore.Client.Functions.V2;
using Gecko.NCore.Client.ObjectModel;
using Gecko.NCore.Client.ObjectModel.V3.En;
using Microsoft.Extensions.Options;

namespace Fint.Sse.Adapter.Services.NCore
{
    public class NCoreFactory
    {
        private readonly NCoreOptions _options;

        public NCoreFactory(IOptions<NCoreOptions> optionsMonitor) : this(optionsMonitor.Value)
        {
        }

        public NCoreFactory(NCoreOptions options)
        {
            _options = options;
        }

        public IEphorteContext Create()
        {
            var servicesBaseUrl = new Uri(_options.NCoreBaseAddress, UriKind.Absolute);

            var identity = new EphorteContextIdentity
            {
                ExternalSystemName = _options.ExternalSystemName,
                Database = _options.Database,
                Username = _options.Username,
                Password = _options.Password,
            };
            
            var objectModelAdapter = GetObjectModelAdapter(servicesBaseUrl, identity);
           
            var functionsAdapter = GetFunctionsAdapter(servicesBaseUrl, identity, _options.FunctionServiceVersion);
            
            var documentsAdapter = GetDocumentsAdapter(servicesBaseUrl, identity);
            
            return new EphorteContext(objectModelAdapter, functionsAdapter, documentsAdapter);
        }

        private static IObjectModelAdapter GetObjectModelAdapter(Uri servicesBaseUrl, EphorteContextIdentity identity)
        {
            var objectModelServiceUrl = "services/objectmodel/v3/en/ObjectModelService.svc";

            var objectModelServiceAddress = new Uri(servicesBaseUrl, objectModelServiceUrl);

            return new ObjectModelAdapterV3En(identity, new ClientSettings
            {
                Address = objectModelServiceAddress.ToString(),
            });
        }

        private static IFunctionsAdapter GetFunctionsAdapter(Uri servicesBaseUrl, EphorteContextIdentity identity,
            string functionServiceVersion)
        {
            var functionServiceUrl = "v1".Equals(functionServiceVersion, StringComparison.OrdinalIgnoreCase)
                ? "services/Functions/V1/FunctionsService.svc/ws"
                : "services/Functions/V2/FunctionsService.svc";

            var functionsServiceAddress = new Uri(servicesBaseUrl, functionServiceUrl);

            return new FunctionsAdapter(identity, new ClientSettings
            {
                Address = functionsServiceAddress.ToString(),
            });
        }

        private static IDocumentsAdapter GetDocumentsAdapter(Uri servicesBaseUrl, EphorteContextIdentity identity)
        {
            var documentsServiceUrl = "services/documents/v2/DocumentService.svc";

            var documentServiceAddress = new Uri(servicesBaseUrl, documentsServiceUrl);

            return new DocumentsAdapter(identity, new ClientSettings
            {
                Address = documentServiceAddress.ToString(),
            });
        }
    }
}
