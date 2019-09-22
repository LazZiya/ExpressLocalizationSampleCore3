namespace ExpressLocalizationSampleCore3Mvc.LocalizationResources
{
    public struct LocalizedBackendMessages
    {
        public const string ChangePasswordSuccess = "Your password has been changed.";

        public const string EnableAuthenticatorSuccess = "Your authenticator app has been verified.";
        public const string ExternalLoginsRemoveSuccess = "The external login was removed.";
        public const string ExternalLoginsAddSuccess = "The external login was added.";

        public const string GeneraterecoveryCodesSuccess = "You have generated new recovery codes.";

        public const string UserProfileUpdateSuccess = "Your profile has been updated";
        public const string VerificationEmailTitle = "Confirm your email";
        public const string VerificationEmailBody = "Please confirm your account by <a href='{0}'>clicking here</a>.";
        public const string VerificationEmailSent = "Verification email sent. Please check your email.";

        public const string ResetAuthenticationSuccess = "Your authenticator app key has been reset, you will need to configure your authenticator app using the new key.";

        public const string TwoFAForgetBrowserSuccess = "The current browser has been forgotten. When you login again from this browser you will be prompted for your 2fa code.";
        public const string TwoFADisableSuccess = "2fa has been disabled. You can reenable 2fa when you setup an authenticator app";

        public const string ExternalLoginsProviderError = "Error from external provider: {0}";
        public const string ExternalLoginsLoadingError = "Error loading external login information.";
        public const string ExternalLoginsLoadingConfirmationError = "Error loading external login information during confirmation.";

        public const string ResetPasswordEmailTitle = "Reset Password";
        public const string ResetPasswordEmailBody = "Please reset your password by <a href='{0}'>clicking here</a>.";

        public const string LoginInvalidAttempt = "Invalid login attempt.";
        public const string InvalidAuthenticationCode = "Invalid authenticator code.";
        public const string InvalidRecoveryCode = "Invalid recovery code entered.";

        public const string PasswordIncorrect = "Password not correct.";

        public const string PasswordSetSuccess = "Your password has been set.";
    }
}
