﻿using System;
using System.Linq;
using System.Text;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class EntityReference : Base
    {
        public EntityReference()
        {

        }

        public EntityReference(Entity entity)
        {
            this.External_Key = entity.External_Key;
            this.ID = System.Convert.ToInt64(getID(entity));
        }

        public EntityReference(long id)
        {
            this.ID = id;
        }

        public long ID { get; set; }

        public string RowVersion { get; set; }

        public string External_Key { get; set; }
        public string External_RowVersion { get; set; }

        public long? External_COR_ID { get; set; }

        public override bool Equals(object obj)
        {
            if (this.ID == 0 && string.IsNullOrEmpty(this.External_Key))
                throw new ArgumentNullException("External_Key");

            if (obj is EntityReference)
                return this.ID>0
                    ? (obj as EntityReference).ID == this.ID 
                    : (obj as EntityReference).External_Key == this.External_Key;

            return base.Equals(obj);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (ID > 0)
                sb.Append(this.ID.ToString());
            if(!string.IsNullOrEmpty(this.External_Key))
            {
                if (sb.Length > 0)
                    sb.Append(", ");
                sb.Append(this.External_Key);
            }
            return sb.ToString();
        }

        protected static object getID(object fromObject)
        {
            var type = fromObject.GetType();
            var idProp = type.GetProperty(type.Name + "ID");
            if (idProp != null)
                return idProp.GetValue(fromObject, null);

            idProp = type.BaseType.GetProperty(type.BaseType.Name + "ID");
            if (idProp != null)
                return idProp.GetValue(fromObject, null);

            idProp = type.GetProperty("ID");
            if (idProp != null)
                return idProp.GetValue(fromObject, null);

            idProp = type.BaseType.BaseType != null
                ? type.BaseType.GetProperty(type.BaseType.BaseType.Name + "ID")
                : null;
            if (idProp != null)
                return idProp.GetValue(fromObject, null);

            foreach (var prop in type.GetProperties().Where(m => !m.Name.Contains("_") && m.Name.EndsWith("ID")))
                return prop.GetValue(fromObject, null);

            throw new Exception("Primary Key not found");
        }
    }

    public class EntityReferenceWithType : EntityReference
    {
        public string Type { get; set; }
    }

    public class VoucherEntityReference : EntityReference
    {
        public string Code { get; set; }

    }
    public class EntityReferenceWithNumber : EntityReference
    {
        public EntityReferenceWithNumber()
            : base()
        {

        }

        public string Number { get; set; }
    }

    public class EntityReferenceWithKey : EntityReference
    {
        public string Key { get; set; }
    }

    public class PictureEntityReference : EntityReference
    {
        public PictureEntityReference()
        {

        }

        public PictureEntityReference(long id)
            :base(id)
        {
        }

        public string Url { get; set; }
        public string Name { get; set; }
        public int Revision { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class DataFileEntityReference : EntityReference
    {

        public string Url { get; set; }
    }

    public class ArticleKeyEntityReference : EntityReference
    {
        public string Value { get; set; }
    }

    public class TaxRateEntityReference : EntityReference
    {
        public double Percent { get; set; }

        public TaxRateEntityReference()
            :base()
        {

        }

        public TaxRateEntityReference(long id)
            :base(id)
        {
        }
    }

    public class EntityReferenceWithGuid : EntityReference
    {
        public Guid Guid { get; set; }
    }

}
