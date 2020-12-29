﻿using ObservableUtils;
using System;

namespace TVTComment.Model.ChatCollectServiceEntry
{
    class PastNichanChatCollectServiceEntry : IChatCollectServiceEntry
    {
        public ChatService.IChatService Owner { get; }

        public string Id => "2chPast";
        public string Name => "2ch過去ログ";
        public string Description => "2chの過去ログを自動で表示";

        public bool CanUseDefaultCreationOption => true;

        public PastNichanChatCollectServiceEntry(
            ChatService.NichanChatService chatService,
            NichanUtils.ThreadResolver threadResolver,
            ObservableValue<TimeSpan> backTime
        )
        {
            this.Owner = chatService;
            this.threadResolver = threadResolver;
            this.backTime = backTime;
        }

        public ChatCollectService.IChatCollectService GetNewService(IChatCollectServiceCreationOption creationOption)
        {
            var boardSelector = new NichanUtils.AutoNichanBoardSelector(this.threadResolver);
            return new ChatCollectService.PastNichanChatCollectService(
                this, boardSelector, this.backTime.Value
            );
        }

        private readonly NichanUtils.ThreadResolver threadResolver;
        private readonly ObservableValue<TimeSpan> backTime;
    }
}
