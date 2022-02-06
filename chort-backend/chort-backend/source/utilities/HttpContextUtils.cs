namespace chort_backend.source.utilities
{
    public static class HttpContextUtils
    {
        public static async Task<string> Json(this HttpContext context)
        {
            //context.Request.Body.Position = 0;
            string body;

            using (var inputStream = new StreamReader(context.Request.Body))
            {
                body = await inputStream.ReadToEndAsync();
            }

            return body;
        }
    }
}
