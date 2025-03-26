namespace AlbanianXrm.PowerPlatform
{
    public enum Strictness
    {
        /// <summary>
        /// <see cref="System.Text.Json.JsonException"/> will be thrown when unknown type is met when Deserializing or Serializing.
        /// </summary>
        Strict = 0,
        /// <summary>
        /// When unknown type is met when Deserializing or Serializing, it will be written as null and read as default.
        /// </summary>
        Loose = 1
    }
}