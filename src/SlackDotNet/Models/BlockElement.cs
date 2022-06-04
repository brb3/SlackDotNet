using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class BlockElement
    {
        /// <summary>
        /// The type of the element.
        ///
        /// Possible values:
        /// `button`, `checkboxes`, `datepicker`, `image`, `multi_static_select`, `multi_external_select`,
        /// `multi_users_select`, `multi_conversations_list`, `multi_channels_select`, `overflow`,
        /// `plain_text_input`, `radio_buttons`, `static_select`, `external_select`, `users_select`,
        /// `conversations_select`, `channels_select`, `timepicker`
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public TextBlock Text { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("style")]
        public string Style { get; set; }

        [JsonProperty("confirm")]
        public ConfirmDialog Confirm { get; set; }

        [JsonProperty("accessibility_label")]
        public string AccessibilityLabel { get; set; }

        [JsonProperty("options")]
        public List<Option> Options { get; set; }

        [JsonProperty("initial_options")]
        public List<Option> InitialOptions { get; set; }

        [JsonProperty("focus_on_load")]
        public bool? FocusOnLoad { get; set; }

        [JsonProperty("placeholder")]
        public TextBlock Placeholder { get; set; }

        /// <summary>
        /// Format `YYYY-MM-DD`
        /// </summary>
        [JsonProperty("initial_date")]
        public string IntialDate { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("alt_text")]
        public string AltText { get; set; }

        [JsonProperty("option_groups")]
        public List<OptionGroup> OptionGroups { get; set; }

        [JsonProperty("max_selected_items")]
        public int? MaxSelectedItems { get; set; }

        [JsonProperty("min_query_length")]
        public int? MinQueryLength { get; set; }

        [JsonProperty("initial_conversations")]
        public List<string> InitialConversations { get; set; }

        [JsonProperty("default_to_current_conversation")]
        public bool? DefaultToCurrentConversation { get; set; }

        [JsonProperty("filter")]
        public Filter Filter { get; set; }

        [JsonProperty("initial_channels")]
        public List<string> InitialChannels { get; set; }

        [JsonProperty("multiline")]
        public bool? Multiline { get; set; }

        [JsonProperty("dispatch_action_config")]
        public DispatchConfiguration DispatchActionConfig { get; set; }

        [JsonProperty("initial_user")]
        public string InitialUser { get; set; }

        [JsonProperty("response_url_enabled")]
        public bool? ResponseUrlEnabled { get; set; }

        /// <summary>
        /// Format `HH:mm` where HH is the 24-hour format of an hour (00 to 23) and mm is minutes with leading zeros (00 to 59)
        /// </summary>
        [JsonProperty("initial_time")]
        public string InitialTime { get; set; }

        [JsonProperty("initial_value")]
        public string InitialValue { get; set; }

        [JsonProperty("min_length")]
        public int? MinLength { get; set; } = null;

        [JsonProperty("max_length")]
        public int? MaxLength { get; set; } = null;
    }
}
