    using Newtonsoft.Json;
    using System;
    using System.Net;

namespace ListingScreenAPI.Model.DataContract.Response
{ 
    public class CommonResponse
{
    [JsonProperty("code")]
    public HttpStatusCode Code { get; set; }

    [JsonProperty("message")]
    public string? Message { get; set; }

    [JsonProperty("data")]
    public object? Data { get; set; }

    [JsonProperty("errors")]
    public object? Errors { get; set; }

    public void SetSuccessStatus(object? data = null, string message = "Success")
    {
        SetStatus(HttpStatusCode.OK, (data == null ? new { } : data), message);
    }

    public void SetStatus(HttpStatusCode statusCode, object? data = null, string message = "Error", object? errors = null)
    {
        this.Code = statusCode;
        this.Message = message;
        this.Data = (data == null ? new { } : data);
        this.Errors = (errors == null ? new { } : errors);

        if (data != null)
        {
            if (data.GetType() == typeof(string))
                this.Data = string.IsNullOrEmpty(data.ToString()) ? new { } : data;
        }

    }
}


}