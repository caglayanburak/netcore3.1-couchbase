using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetcoreCouchbase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BacklogController : ControllerBase
    {
        private readonly ILogger<BacklogController> _logger;
        private readonly IBucket _bucket;

        public BacklogController(ILogger<BacklogController> logger, IBucketProvider bucketProvider)
        {
            _logger = logger;
            _bucket = bucketProvider.GetBucket("backlog");
        }

        [HttpGet]
        public long[] Get()
        {
            var t = _bucket.Get<BucketObject>("Ghost:7330TEST01");

            return t.Value.cIds;
        }
    }

    public class BucketObject
    {
        public long[] cIds { get; set; }
    }
}
