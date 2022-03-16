﻿using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;
using GS.PflanzenCMS.Rest.SDK.Classes;
using Microsoft.Win32;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class PicturesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Picture, GS.PflanzenCMS.Rest.SDK.Models.Picture.Summary>, IPicturesRepository
    {
        protected string getMimeType(string filename)
        {
            string mimeType = "application/unknown";

            RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(
                System.IO.Path.GetExtension(filename).ToLower()
                );

            if (regKey != null)
            {
                object contentType = regKey.GetValue("Content Type");

                if (contentType != null)
                    mimeType = contentType.ToString();
            }

            return mimeType;
        }

        public PicturesRepository(Context context)
            :base(context, "api/pictures")
        {
            
        }

        public Picture Upload(UploadArgs args)
        {
            return this.context.UploadPicture(args);
        }

        public Picture Upload(string filename)
        {
            return Upload(
                new UploadArgs()
                {
                    Data = new DataUri(System.IO.File.ReadAllBytes(filename)).ToString(),
                    Filename = System.IO.Path.GetFileName(filename),
                    Type = getMimeType(filename)
                }
            );
        }
    }
}