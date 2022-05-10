using SlackDotNet.Models.Messages.Payloads.EventsAPI;

namespace SlackDotNet.Enums
{
    public enum EventsAPIType
    {
        [Type(typeof(AppHomeOpened))]
        app_home_opened,

        [Type(typeof(AppMention))]
        app_mention,

        [Type(typeof(AppRateLimited))]
        app_rate_limited,

        [Type(typeof(AppRequested))]
        app_requested,

        [Type(typeof(AppUninstalled))]
        app_uninstalled,

        [Type(typeof(CallRejected))]
        call_rejected,

        [Type(typeof(ChannelArchive))]
        channel_archive,

        [Type(typeof(ChannelCreated))]
        channel_created,

        [Type(typeof(ChannelDeleted))]
        channel_deleted,

        [Type(typeof(ChannelHistoryChanged))]
        channel_history_changed,

        [Type(typeof(ChannelIdChanged))]
        channel_id_changed,

        [Type(typeof(ChannelLeft))]
        channel_left,

        [Type(typeof(ChannelRename))]
        channel_rename,

        [Type(typeof(ChannelShared))]
        channel_shared,

        [Type(typeof(ChannelUnarchive))]
        channel_unarchive,

        [Type(typeof(ChannelUnshared))]
        channel_unshared,

        [Type(typeof(DndUpdated))]
        dnd_updated,

        [Type(typeof(DndUpdatedUser))]
        dnd_updated_user,

        [Type(typeof(EmailDomainChanged))]
        email_domain_changed,

        [Type(typeof(EmojiChanged))]
        emoji_changed,

        [Type(typeof(FileChange))]
        file_change,

        [Type(typeof(FileCreated))]
        file_created,

        [Type(typeof(FileDeleted))]
        file_deleted,

        [Type(typeof(FilePublic))]
        file_public,

        [Type(typeof(FileShared))]
        file_shared,

        [Type(typeof(FileUnshared))]
        file_unshared,

        [Type(typeof(GroupArchive))]
        group_archive,

        [Type(typeof(GroupClose))]
        group_close,

        [Type(typeof(GroupDeleted))]
        group_deleted,

        [Type(typeof(GroupHistoryChanged))]
        group_history_changed,

        [Type(typeof(GroupLeft))]
        group_left,

        [Type(typeof(GroupOpen))]
        group_open,

        [Type(typeof(GroupRename))]
        group_rename,

        [Type(typeof(GroupUnarchive))]
        group_unarchive,

        [Type(typeof(ImClose))]
        im_close,

        [Type(typeof(ImCreated))]
        im_created,

        [Type(typeof(ImHistoryChanged))]
        im_history_changed,

        [Type(typeof(ImOpen))]
        im_open,

        [Type(typeof(InviteRequested))]
        invite_requested,

        [Type(typeof(LinkShared))]
        link_shared,

        [Type(typeof(MemberJoinedChannel))]
        member_joined_channel,

        [Type(typeof(MemberLeftChannel))]
        member_left_channel,

        [Type(typeof(Message))]
        message,

        [Type(typeof(PinAdded))]
        pin_added,

        [Type(typeof(PinRemoved))]
        pin_removed,

        [Type(typeof(ReactionAdded))]
        reaction_added,

        [Type(typeof(ReactionRemoved))]
        reaction_removed,

        [Type(typeof(SharedChannelInviteAccepted))]
        shared_channel_invite_accepted,

        [Type(typeof(SharedChannelInviteApproved))]
        shared_channel_invite_approved,

        [Type(typeof(SharedChannelInviteDeclined))]
        shared_channel_invite_declined,

        [Type(typeof(SharedChannelInviteReceived))]
        shared_channel_invite_received,

        [Type(typeof(StarAdded))]
        star_added,

        [Type(typeof(StarRemoved))]
        star_removed,

        [Type(typeof(SubteamCreated))]
        subteam_created,

        [Type(typeof(SubteamMembersChanged))]
        subteam_members_changed,

        [Type(typeof(SubteamSelfAdded))]
        subteam_self_added,

        [Type(typeof(SubteamSelfRemoved))]
        subteam_self_removed,

        [Type(typeof(SubteamUpdated))]
        subteam_updated,

        [Type(typeof(TeamAccessGranted))]
        team_access_granted,

        [Type(typeof(TeamAccessRevoked))]
        team_access_revoked,

        [Type(typeof(TeamDomainChange))]
        team_domain_change,

        [Type(typeof(TeamJoin))]
        team_join,

        [Type(typeof(TeamRename))]
        team_rename,

        [Type(typeof(TokensRevoked))]
        tokens_revoked,

        [Type(typeof(UserChange))]
        user_change,

        [Type(typeof(UserHuddleChanged))]
        user_huddle_changed,

        [Type(typeof(UserProfileChanged))]
        user_profile_changed,

        [Type(typeof(UserStatusChanged))]
        user_status_changed,

        [Type(typeof(WorkflowDeleted))]
        workflow_deleted,

        [Type(typeof(WorkflowPublished))]
        workflow_published,

        [Type(typeof(WorkflowStepDeleted))]
        workflow_step_deleted,

        [Type(typeof(WorkflowStepExecute))]
        workflow_step_execute,

        [Type(typeof(WorkflowUnpublished))]
        workflow_unpublished
    }
}
