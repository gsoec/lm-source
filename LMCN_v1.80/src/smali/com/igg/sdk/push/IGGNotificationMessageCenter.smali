.class public Lcom/igg/sdk/push/IGGNotificationMessageCenter;
.super Ljava/lang/Object;
.source "IGGNotificationMessageCenter.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;,
        Lcom/igg/sdk/push/IGGNotificationMessageCenter$IGGPushMesageListener;,
        Lcom/igg/sdk/push/IGGNotificationMessageCenter$BroadcastCodeReceiver;
    }
.end annotation


# static fields
.field public static final ACTION_CODE_RECEIVER:Ljava/lang/String; = "action.IGGNotification_message_rceiver"

.field private static final TAG:Ljava/lang/String; = "IGGNotificationCenter"

.field private static instance:Lcom/igg/sdk/push/IGGNotificationMessageCenter;


# instance fields
.field private config:Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;

.field private context:Landroid/content/Context;

.field private ifReg:Z

.field private listeners:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;",
            "Lcom/igg/sdk/push/IGGNotificationMessageCenter$IGGPushMesageListener;",
            ">;"
        }
    .end annotation
.end field

.field receiver:Lcom/igg/sdk/push/IGGNotificationMessageCenter$BroadcastCodeReceiver;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 42
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 125
    new-instance v0, Lcom/igg/sdk/push/IGGNotificationMessageCenter$BroadcastCodeReceiver;

    invoke-direct {v0, p0}, Lcom/igg/sdk/push/IGGNotificationMessageCenter$BroadcastCodeReceiver;-><init>(Lcom/igg/sdk/push/IGGNotificationMessageCenter;)V

    iput-object v0, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->receiver:Lcom/igg/sdk/push/IGGNotificationMessageCenter$BroadcastCodeReceiver;

    .line 43
    new-instance v0, Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;

    invoke-direct {v0}, Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->config:Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;

    .line 44
    return-void
.end method

.method static synthetic access$000(Lcom/igg/sdk/push/IGGNotificationMessageCenter;)Ljava/util/Map;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    .prologue
    .line 22
    iget-object v0, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->listeners:Ljava/util/Map;

    return-object v0
.end method

.method private registerSevicer()V
    .locals 3

    .prologue
    .line 82
    iget-boolean v1, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->ifReg:Z

    if-nez v1, :cond_0

    .line 83
    const-string v1, "IGGNotificationCenter"

    const-string v2, "registerReceiver"

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 84
    new-instance v0, Landroid/content/IntentFilter;

    invoke-direct {v0}, Landroid/content/IntentFilter;-><init>()V

    .line 85
    .local v0, "filter":Landroid/content/IntentFilter;
    const-string v1, "action.IGGNotification_message_rceiver"

    invoke-virtual {v0, v1}, Landroid/content/IntentFilter;->addAction(Ljava/lang/String;)V

    .line 86
    iget-object v1, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->context:Landroid/content/Context;

    iget-object v2, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->receiver:Lcom/igg/sdk/push/IGGNotificationMessageCenter$BroadcastCodeReceiver;

    invoke-virtual {v1, v2, v0}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    .line 87
    const/4 v1, 0x1

    iput-boolean v1, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->ifReg:Z

    .line 89
    .end local v0    # "filter":Landroid/content/IntentFilter;
    :cond_0
    return-void
.end method

.method public static sharedInstance()Lcom/igg/sdk/push/IGGNotificationMessageCenter;
    .locals 1

    .prologue
    .line 35
    sget-object v0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->instance:Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    if-nez v0, :cond_0

    .line 36
    new-instance v0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    invoke-direct {v0}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;-><init>()V

    sput-object v0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->instance:Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    .line 39
    :cond_0
    sget-object v0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->instance:Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    return-object v0
.end method


# virtual methods
.method public addPushMessageLister(Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;Lcom/igg/sdk/push/IGGNotificationMessageCenter$IGGPushMesageListener;)V
    .locals 1
    .param p1, "type"    # Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;
    .param p2, "listener"    # Lcom/igg/sdk/push/IGGNotificationMessageCenter$IGGPushMesageListener;

    .prologue
    .line 64
    iget-object v0, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->listeners:Ljava/util/Map;

    if-eqz v0, :cond_0

    .line 65
    iget-object v0, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->listeners:Ljava/util/Map;

    invoke-interface {v0, p1, p2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 67
    :cond_0
    return-void
.end method

.method public getConfig()Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;
    .locals 1

    .prologue
    .line 137
    iget-object v0, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->config:Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;

    return-object v0
.end method

.method public init(Landroid/content/Context;)V
    .locals 1
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 52
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->listeners:Ljava/util/Map;

    .line 53
    iput-object p1, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->context:Landroid/content/Context;

    .line 55
    invoke-direct {p0}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->registerSevicer()V

    .line 56
    return-void
.end method

.method public isReg()Z
    .locals 1

    .prologue
    .line 75
    iget-boolean v0, p0, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->ifReg:Z

    return v0
.end method
