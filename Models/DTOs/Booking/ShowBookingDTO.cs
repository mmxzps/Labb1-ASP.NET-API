using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Globalization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Labb1_ASP.NET_API.Models.DTOs.Booking
{
    public class ShowBookingDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int AmountGuest { get; set; }
        [JsonConverter(typeof(CustomDate))]
        public DateTime BookingDate { get; set; }

        [JsonConverter(typeof(CustomDate))]
        public DateTime BookingDateEnd { get; set; }
        public int TableId { get; set; }
        public int TableNumber { get; set; }
    }

    //Changes the format of the Date showing. 
    public class CustomDate : JsonConverter<DateTime>
    {
        private const string _format = "yyyy-MM-dd HH:mm";

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format));
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            //extra check if date is null or written in wrong format.
            string dateString = reader.GetString();
            if (string.IsNullOrEmpty(dateString)) 
            {
                return DateTime.MinValue;
            }

            try
            {
                return DateTime.ParseExact(dateString, _format, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return DateTime.MinValue;
            }
        }
    }
    //Changeing format of datetime in swagger
    public class DateTimeSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(DateTime) || context.Type == typeof(DateTime?))
            {
                schema.Example = new Microsoft.OpenApi.Any.OpenApiString(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm"));
            }
        }
    }
}
