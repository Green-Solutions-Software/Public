using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Interfaces
{
    public interface IPicturesRepository : IRepository<GS.PflanzenCMS.Rest.SDK.Models.Picture, GS.PflanzenCMS.Rest.SDK.Models.Picture.Summary>
    {
        Picture Upload(UploadArgs args);

        Picture Upload(string filename);
    }
}
