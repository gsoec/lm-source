.class public Lcom/igg/sdk/push/IGGNotificationMessageCenter$BroadcastCodeReceiver;
.super Landroid/content/BroadcastReceiver;
.source "IGGNotificationMessageCenter.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/push/IGGNotificationMessageCenter;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = "BroadcastCodeReceiver"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/push/IGGNotificationMessageCenter;


# direct methods
.method public constructor <init>(Lcom/igg/sdk/push/IGGNotificationMessageCenter;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    .prologue
    .line 96
    iput-object p1, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter$BroadcastCodeReceiver;->this$0:Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    invoke-direct {p0}, Landroid/content/BroadcastReceiver;-><init>()V

    return-void
.end method


# virtual methods
.method public onReceive(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 7
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "intent"    # Landroid/content/Intent;

    .prologue
    .line 100
    const-string v4, "IGGNotificationCenter"

    const-string v5, "BroadcastCodeReceiver"

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 101
    invoke-virtual {p2}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v0

    .line 102
    .local v0, "bundle":Landroid/os/Bundle;
    new-instance v1, Lcom/igg/sdk/bean/PushCommonMessageInfo;

    invoke-direct {v1}, Lcom/igg/sdk/bean/PushCommonMessageInfo;-><init>()V

    .line 103
    .local v1, "info":Lcom/igg/sdk/bean/PushCommonMessageInfo;
    invoke-virtual {p2}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v4

    const-string v5, "msg"

    invoke-virtual {v4, v5}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v1, v4}, Lcom/igg/sdk/bean/PushCommonMessageInfo;->setMessage(Ljava/lang/String;)V

    .line 104
    invoke-virtual {p2}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v4

    const-string v5, "m_qid"

    invoke-virtual {v4, v5}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v1, v4}, Lcom/igg/sdk/bean/PushCommonMessageInfo;->setMqId(Ljava/lang/String;)V

    .line 105
    invoke-virtual {p2}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v4

    const-string v5, "m_display"

    invoke-virtual {v4, v5}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v1, v4}, Lcom/igg/sdk/bean/PushCommonMessageInfo;->setDisplay(Ljava/lang/String;)V

    .line 106
    invoke-virtual {p2}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v4

    const-string v5, "m_state"

    invoke-virtual {v4, v5}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v1, v4}, Lcom/igg/sdk/bean/PushCommonMessageInfo;->setMessageState(Ljava/lang/String;)V

    .line 107
    const-string v4, "m_crm"

    invoke-virtual {v0, v4}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 109
    .local v2, "message":Ljava/lang/String;
    iget-object v4, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter$BroadcastCodeReceiver;->this$0:Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    invoke-static {v4}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->access$000(Lcom/igg/sdk/push/IGGNotificationMessageCenter;)Ljava/util/Map;

    move-result-object v4

    invoke-interface {v4}, Ljava/util/Map;->keySet()Ljava/util/Set;

    move-result-object v4

    invoke-interface {v4}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v5

    :cond_0
    :goto_0
    invoke-interface {v5}, Ljava/util/Iterator;->hasNext()Z

    move-result v4

    if-eqz v4, :cond_3

    invoke-interface {v5}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;

    .line 110
    .local v3, "type":Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;
    sget-object v4, Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;->CRM:Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;

    if-ne v3, v4, :cond_1

    .line 111
    if-eqz v2, :cond_0

    const-string v4, ""

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 113
    iget-object v4, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter$BroadcastCodeReceiver;->this$0:Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    invoke-static {v4}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->access$000(Lcom/igg/sdk/push/IGGNotificationMessageCenter;)Ljava/util/Map;

    move-result-object v4

    sget-object v6, Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;->CRM:Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;

    invoke-interface {v4, v6}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/igg/sdk/push/IGGNotificationMessageCenter$IGGPushMesageListener;

    invoke-interface {v4, v1, v2}, Lcom/igg/sdk/push/IGGNotificationMessageCenter$IGGPushMesageListener;->handleMessage(Lcom/igg/sdk/bean/PushCommonMessageInfo;Ljava/lang/String;)V

    goto :goto_0

    .line 115
    :cond_1
    sget-object v4, Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;->SDK:Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;

    if-ne v3, v4, :cond_0

    .line 116
    if-eqz v2, :cond_2

    const-string v4, ""

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_0

    .line 118
    :cond_2
    iget-object v4, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter$BroadcastCodeReceiver;->this$0:Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    invoke-static {v4}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->access$000(Lcom/igg/sdk/push/IGGNotificationMessageCenter;)Ljava/util/Map;

    move-result-object v4

    sget-object v6, Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;->SDK:Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;

    invoke-interface {v4, v6}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/igg/sdk/push/IGGNotificationMessageCenter$IGGPushMesageListener;

    invoke-virtual {v1}, Lcom/igg/sdk/bean/PushCommonMessageInfo;->getMessage()Ljava/lang/String;

    move-result-object v6

    invoke-interface {v4, v1, v6}, Lcom/igg/sdk/push/IGGNotificationMessageCenter$IGGPushMesageListener;->handleMessage(Lcom/igg/sdk/bean/PushCommonMessageInfo;Ljava/lang/String;)V

    goto :goto_0

    .line 122
    .end local v3    # "type":Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;
    :cond_3
    return-void
.end method
