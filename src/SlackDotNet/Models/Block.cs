using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class Block
    {
        /// <summary>
        /// The type of the block:
        /// `actions`, `context`, `divider`, `file`, `header`, `image`, `input`, `section`
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// An array of interactive elemnts.
        /// Max of 25.
        ///
        /// Valid for: `actions`, `context`
        /// </summary>
        [JsonProperty("elements")]
        public List<BlockElement> Elements { get; set; }

        /// <summary>
        /// A string acting as a unique identifier for a block.
        /// If not specified, a block_id will be generated.
        /// You can use this block_id when you receive an interaction payload to identify the source of the action.
        /// Maximum length for this field is 255 characters.
        /// block_id should be unique for each message and each iteration of a message.
        /// If a message is updated, use a new block_id.
        ///
        /// Valid for: `actions`, `context`, `divider`, `file`, `header`, `image`, `input`, `section`
        /// </summary>
        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        /// <summary>
        /// The external unique ID for this file.
        ///
        /// Valid for: `file`
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// At the moment, source should always be `remote` for a remote file.
        ///
        /// Valid for: `file`
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        /// The text for the block, in the form of a `plain_text` text object.
        /// Maximum length for the text in this field is 150 characters.
        ///
        /// Valid for: `header`, `section`
        /// </summary>
        [JsonProperty("text")]
        public TextBlock Text { get; set; }

        /// <summary>
        /// The URL of the image to be displayed. Maximum length for this field is 3000 characters.
        ///
        /// Valid for: `image`
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// A plain-text summary of the image. This should not contain any markup.
        /// Maximum length for this field is 2000 characters
        ///
        /// Valid for: `image`
        /// </summary>
        [JsonProperty("alt_text")]
        public string AltText { get; set; }

        /// <summary>
        /// An optional title for the image in the form of a text object that can only be of type: plain_text.
        /// Maximum length for the text in this field is 2000 characters.
        ///
        /// Valid for: `image`
        /// </summary>
        [JsonProperty("title")]
        public TextBlock Title { get; set; }

        /// <summary>
        /// A label that appears above an input element in the form of a text object that must have type of plain_text.
        /// Maximum length for the text in this field is 2000 characters.
        ///
        /// Valid for: `input`
        /// </summary>
        [JsonProperty("label")]
        public TextBlock Label { get; set; }

        /// <summary>
        /// A plain-text input element, a checkbox element, a radio button element, a select menu element,
        /// a multi-select menu element, or a datepicker.
        ///
        /// Valid for: `input`
        /// </summary>
        [JsonProperty("element")]
        public BlockElement Element { get; set; }

        /// <summary>
        /// A boolean that indicates whether or not the use of elements in this block should dispatch a block_actions payload.
        /// Defaults to false.
        ///
        /// Valid for: `input`
        /// </summary>
        [JsonProperty("dispatch_action")]
        public bool DispatchAction { get; set; }

        /// <summary>
        /// An optional hint that appears below an input element in a lighter grey.
        /// It must be a text object with a type of plain_text.
        /// Maximum length for the text in this field is 2000 characters.
        ///
        /// Valid for: `input`
        /// </summary>
        [JsonProperty("hint")]
        public TextBlock Hint { get; set; }

        /// <summary>
        /// A boolean that indicates whether the input element may be empty when a user submits the modal.
        /// Defaults to false.
        ///
        /// Valid for: `input`
        /// </summary>
        [JsonProperty("optional")]
        public bool Optional { get; set; }

        /// <summary>
        /// Required if no text is provided. A List of text objects.
        /// Any text objects included with fields will be rendered in a compact format that allows for 2 columns of side-by-side text.
        /// Maximum number of items is 10. Maximum length for the text in each item is 2000 characters.
        ///
        /// Valid for: `section`
        /// </summary>
        [JsonProperty("fields")]
        public List<TextBlock> Fields { get; set; }

        /// <summary>
        /// One of the available element objects.
        ///
        /// Valid for: `section`
        /// </summary>
        public BlockElement Accessory { get; set; }
    }
}
