/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.records
{

	using JSONObject = Newtonsoft.Json.Linq.JObject;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class SymbolGroupRecord : BaseResponseRecord
	{

		private long? type;
		private string description;
		private string name;

		public SymbolGroupRecord()
		{
		}

	

		public virtual long? Type
		{
			get
			{
				return type;
			}
		}

		public virtual string Description
		{
			get
			{
				return description;
			}
		}

		public virtual string Name
		{
			get
			{
				return name;
			}
		}

        public void FieldsFromJSONObject(JSONObject value)
        {
            this.type = (long?)value["type"];
            this.description = (string)value["description"];
            this.name = (string)value["name"];
        }
    }

}