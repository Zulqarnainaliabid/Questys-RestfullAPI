using System;
using System.Collections.Generic;
using System.Text;

namespace Questys.RestfullAPI.Shared.ServiceHelper.Common.Helpers
{
    public static class ErrorHandler
    {
        /// <summary>
        /// TODO: localization when needed
        /// </summary>
        private const string ERROR_DETAILS = "Error Details";
        private const string FAILED = "failed";
        private const string NOT_PROVIDED = "not provided";

        /// <summary>
        /// Build Error Details
        /// 
        /// Note: any preferred wording/formating/change is welcome
        /// 
        /// </summary>
        /// <param name="message">Error Message</param>
        /// <param name="method">Method name</param>
        /// <param name="info">Any additional information</param>
        /// <returns>Formated Error Details string</returns>
        public static string BuildErrorDetails(string message, string method = null, string info = null) =>
            string.IsNullOrEmpty(method)
                ? string.IsNullOrEmpty(info)
                    ? $"{ERROR_DETAILS}: {message}"
                    : $"{ERROR_DETAILS}: {message}{Environment.NewLine}{info}"
                : string.IsNullOrEmpty(info)
                    ? $"{ERROR_DETAILS}: {method} {FAILED}. {message}"
                    : $"{ERROR_DETAILS}: {method} {FAILED}. {message}{Environment.NewLine}{info}";

        /// <summary>
        /// Build Error Message
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="info">Any additional information</param>
        /// <returns>Formated Full Error Message</returns>
        public static string BuildErrorMessage(Exception exception, string info = null)
        {
            var baseMessage = exception?.GetBaseException()?.Message ?? string.Empty;
            var error = string.IsNullOrEmpty(info)
                ? baseMessage
                : $"{info.TrimEnd('.')}. {baseMessage}";

            var message = new StringBuilder(error);
            var innerException = exception?.InnerException;
            while (innerException != null)
            {
                message.AppendLine(innerException.Message ?? string.Empty);
                innerException = innerException.InnerException;
            }

            return message.ToString();
        }

        /// <summary>
        /// Build User Friendly Error Message
        /// 
        /// Note: any preferred wording/formating/change is welcome
        /// 
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="info">Any additional information</param>
        /// <returns>User Friendly Formated Error Message</returns>
        public static string UserFriendlyErrorMessage(Exception exception, string info = null)
        {
            var baseMessage = exception?.GetBaseException()?.Message ?? string.Empty;

            return string.IsNullOrEmpty(info)
                ? baseMessage
                : $"{info.TrimEnd('.')}. {baseMessage}";
        }

        /// <summary>
        /// Get Argument Exception Message
        /// </summary>
        /// <param name="argumentName">argumentName</param>
        /// <param name="methodName">methodName</param>
        /// <returns>Formated Argument Exception Message</returns>
        public static string ArgumentExceptionMessage(string argumentName, string methodName = null) =>
            string.IsNullOrEmpty(methodName)
                ? $"{argumentName} {NOT_PROVIDED}."
                : $"{methodName}: {argumentName} {NOT_PROVIDED}.";
    }
}
