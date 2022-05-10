using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class View
    {
        /// <summary>
        /// The type of view. Set to modal for modals and home for Home tabs.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The title that appears in the top-left of the modal.
        /// Must be a plain_text text element with a max length of 24 characters.
        /// </summary>
        [JsonProperty("title")]
        public TextBlock Title { get; set; }

        /// <summary>
        /// An array of blocks that defines the content of the view. Max of 100 blocks.
        /// </summary>
        [JsonProperty("blocks")]
        public List<Block> Blocks { get; set; }

        /// <summary>
        /// An optional plain_text element that defines the text displayed in the close button at the bottom-right of the view.
        /// Max length of 24 characters.
        /// </summary>
        [JsonProperty("close")]
        public TextBlock Close { get; set; }

        /// <summary>
        /// An optional plain_text element that defines the text displayed in the submit button at the bottom-right of the view. submit is required when an input block is within the blocks array.
        /// Max length of 24 characters.
        /// </summary>
        [JsonProperty("submit")]
        public TextBlock Submit { get; set; }

        /// <summary>
        /// An optional string that will be sent to your app in view_submission and block_actions events.
        /// Max length of 3000 characters.
        /// </summary>
        [JsonProperty("private_metadata")]
        public string PrivateMetadata { get; set; }

        /// <summary>
        /// An identifier to recognize interactions and submissions of this particular view. Don't use this to store sensitive information (use private_metadata instead).
        /// Max length of 255 characters.
        /// </summary>
        [JsonProperty("callback_id")]
        public string CallbackId { get; set; }

        /// <summary>
        /// When set to true, clicking on the close button will clear all views in a modal and close it.
        /// Defaults to false.
        /// </summary>
        [JsonProperty("clear_on_close")]
        public bool ClearOnClose { get; set; } = false;

        /// <summary>
        /// Indicates whether Slack will send your request URL a view_closed event when a user clicks the close button.
        /// Defaults to false.
        /// </summary>
        [JsonProperty("notify_on_close")]
        public bool NotifyOnClose { get; set; } = false;

        /// <summary>
        /// A custom identifier that must be unique for all views on a per-team basis.
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// When set to true, disables the submit button until the user has completed one or more inputs.
        /// This property is for configuration modals.
        /// </summary>
        [JsonProperty("submit_disabled")]
        public bool SubmitDisabled { get; set; } = false;
    }
}
