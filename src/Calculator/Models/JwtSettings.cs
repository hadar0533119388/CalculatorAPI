namespace Calculator.Models
{
    /// <summary>
    /// Represents the configuration settings required for generating a JWT token.
    /// These values are typically loaded from appsettings.json.
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// The secret key used to sign and validate the JWT. 
        /// Should be long and secure.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// The issuer of the JWT
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// The intended audience of the JWT
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// The token's expiration time in minutes.
        /// </summary>
        public int ExpiryMinutes { get; set; }
    }


}
