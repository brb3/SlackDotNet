namespace SlackDotNet
{
    public class SlackConfig
    {
        public string OauthToken { get; set; }
        public string SigningSecret { get; set; }
        public string VerificationToken { get; set; }

        public SlackConfig(string oauthToken, string signingSecret, string verificationToken)
        {
            OauthToken = oauthToken;
            SigningSecret = signingSecret;
            VerificationToken = verificationToken;
        }
    }
}