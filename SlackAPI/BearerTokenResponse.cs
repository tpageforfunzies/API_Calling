﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackAPI
{
    public class BearerTokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string code { get; set; }
    }
}
