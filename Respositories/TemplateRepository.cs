//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Sky.SelfServe.Models;

namespace Sky.SelfServe.Repositories
{
    public class TemplateRepository
    {
        private readonly SelfServeContext _selfServeContext;

        public TemplateRepository(SelfServeContext selfServeContext)
        {
            _selfServeContext = selfServeContext;
        }

        // public List<Template> GetTemplate(int pageNumber, int pageSize)
        // {
        //     return _schoolContext.Blog.Where(item => item.BlogStatus != (int)BlogStatusEnum.Delete)
        //         .OrderByDescending(item => item.UpdateTime).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        // }

        public List<Partner> GetTemplate()
        {
            return _selfServeContext.Partner.Take(10).ToList();
        }

    }
}
