﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace PreCheck
{
    public partial class JsonDeserialization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string reportContent = @"[
   {
      'editModel':{
         'groupName':'Second',
         'vintageYear':'2000',
         'customBenchmarkGroup':[
            {
               'id':'05130fcf-0d61-45bb-a692-504494e7923a',
               'text':'Complex1',
               'years':[
                  {
                     'vintageYearBy':2,
                     'years':[
                        1986,
                        1987,
                        1988,
                        1989,
                        1990,
                        1991,
                        1992,
                        1993,
                        1994,
                        1995,
                        1996,
                        1997,
                        1998,
                        1999,
                        2000,
                        2001,
                        2002,
                        2003,
                        2005,
                        2007,
                        2009
                     ]
                  },
                  {
                     'vintageYearBy':1,
                     'years':[
                        1986,
                        1987,
                        1988,
                        1989,
                        1990,
                        1991,
                        1992,
                        1993,
                        1994,
                        1995,
                        1996,
                        1997,
                        1998,
                        1999,
                        2000,
                        2001,
                        2002,
                        2003,
                        2004,
                        2005,
                        2006,
                        2007,
                        2008
                     ]
                  }
               ],
               'totals':1000
            },
            {
               'id':'08b4fc9f-8f3b-471e-97ff-cfaec9c57e5c',
               'text':'Complex2',
               'years':[
                  {
                     'vintageYearBy':2,
                     'years':[
                        1981,
                        1982,
                        1983,
                        1984,
                        1985,
                        1986,
                        1987,
                        1988,
                        1989,
                        1990,
                        1991,
                        1992,
                        1993,
                        1994,
                        1995,
                        1996,
                        1997,
                        1998,
                        1999,
                        2000,
                        2001,
                        2002,
                        2003,
                        2004,
                        2005,
                        2008
                     ]
                  },
                  {
                     'vintageYearBy':1,
                     'years':[
                        1981,
                        1982,
                        1983,
                        1984,
                        1985,
                        1986,
                        1987,
                        1988,
                        1989,
                        1990,
                        1991,
                        1992,
                        1993,
                        1994,
                        1995,
                        1996,
                        1997,
                        1998,
                        1999,
                        2000,
                        2001,
                        2002,
                        2003,
                        2004,
                        2005,
                        2008
                     ]
                  }
               ]
            }
         ]
      },
      'id':'54F4E650-8BFF-04D6-561F-3C18851BFCFC',
      'name':'Second',
      'irr':'7.9955 %',
      'includeInCalculation':true,
      'years':[
         {
            'year':2000,
            'customBenchmarkGroups':[
               {
                  'id':'05130fcf-0d61-45bb-a692-504494e7923a',
                  'value':'1000',
                  'hasTransactions':true
               },
               {
                  'id':'08b4fc9f-8f3b-471e-97ff-cfaec9c57e5c',
                  'value':'500',
                  'hasTransactions':true
               }
            ],
            'totals':1500
         }
      ],
      'customBenchmarkGroups':[
         {
            'id':'05130fcf-0d61-45bb-a692-504494e7923a',
            'text':'Complex1',
            'years':[
               {
                  'vintageYearBy':2,
                  'years':[
                     1986,
                     1987,
                     1988,
                     1989,
                     1990,
                     1991,
                     1992,
                     1993,
                     1994,
                     1995,
                     1996,
                     1997,
                     1998,
                     1999,
                     2000,
                     2001,
                     2002,
                     2003,
                     2005,
                     2007,
                     2009
                  ]
               },
               {
                  'vintageYearBy':1,
                  'years':[
                     1986,
                     1987,
                     1988,
                     1989,
                     1990,
                     1991,
                     1992,
                     1993,
                     1994,
                     1995,
                     1996,
                     1997,
                     1998,
                     1999,
                     2000,
                     2001,
                     2002,
                     2003,
                     2004,
                     2005,
                     2006,
                     2007,
                     2008
                  ]
               }
            ],
            'totals':1000
         },
         {
            'id':'08b4fc9f-8f3b-471e-97ff-cfaec9c57e5c',
            'text':'Complex2',
            'totals':500
         }
      ],
      'totals':1500,
      'isInEditMode':false
   }
]";
                /*@'{
  'Name': 'Bad Boys',
  'ReleaseDate': '1995-4-7T00:00:00',
  'Genres': [
    'Action',
    'Comedy'
  ]
}';*/
            //var data = (JObject)JsonConvert.DeserializeObject(reportContent);
            //string Name = data["customBenchmarkGroups/text"].Value<string>();
            dynamic data = JsonConvert.DeserializeObject(reportContent);
            StringBuilder groupIds = new StringBuilder();
            if (data[0].customBenchmarkGroups != null)
            {
                foreach (var s in data[0].customBenchmarkGroups)
                {
                    groupIds.Append(s.id + ",");
                }
            }
            Response.Write(groupIds.ToString());
        }
    }
}