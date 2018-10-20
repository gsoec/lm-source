.class public Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;
.super Ljava/lang/Object;
.source "IGGAppConfigHelper.java"


# static fields
.field private static instance:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;


# instance fields
.field EventCarnivalCallBackFailed:Ljava/lang/String;

.field EventCarnivalCallBackSuccessful:Ljava/lang/String;

.field GameMaintanceCallBackFailed:Ljava/lang/String;

.field GameMaintanceCallBackSuccessful:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 17
    const-string v0, "EventCarnivalCallBackSuccessful"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->EventCarnivalCallBackSuccessful:Ljava/lang/String;

    .line 18
    const-string v0, "EventCarnivalCallBackFailed"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->EventCarnivalCallBackFailed:Ljava/lang/String;

    .line 20
    const-string v0, "GameMaintanceCallBackSuccessful"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->GameMaintanceCallBackSuccessful:Ljava/lang/String;

    .line 21
    const-string v0, "GameMaintanceCallBackFailed"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->GameMaintanceCallBackFailed:Ljava/lang/String;

    return-void
.end method

.method private OpenUrl(Ljava/lang/String;)V
    .locals 3
    .param p1, "pUrl"    # Ljava/lang/String;

    .prologue
    .line 78
    move-object v1, p1

    .line 79
    .local v1, "url":Ljava/lang/String;
    new-instance v0, Landroid/content/Intent;

    const-string v2, "android.intent.action.VIEW"

    invoke-direct {v0, v2}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 80
    .local v0, "intent":Landroid/content/Intent;
    invoke-static {v1}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v2

    invoke-virtual {v0, v2}, Landroid/content/Intent;->setData(Landroid/net/Uri;)Landroid/content/Intent;

    .line 81
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->getActivity()Landroid/app/Activity;

    move-result-object v2

    invoke-virtual {v2, v0}, Landroid/app/Activity;->startActivity(Landroid/content/Intent;)V

    .line 82
    return-void
.end method

.method private getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 93
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;
    .locals 1

    .prologue
    .line 86
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->instance:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    if-nez v0, :cond_0

    .line 87
    new-instance v0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->instance:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    .line 89
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->instance:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    return-object v0
.end method


# virtual methods
.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 24
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 25
    return-void
.end method

.method public LoadEventConfig()V
    .locals 5

    .prologue
    .line 54
    :try_start_0
    new-instance v1, Lcom/igg/sdk/service/IGGAppConfigService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGAppConfigService;-><init>()V

    const-string v2, "event_config"

    sget-object v3, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->DEFAULT:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    new-instance v4, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$2;

    invoke-direct {v4, p0}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$2;-><init>(Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;)V

    invoke-virtual {v1, v2, v3, v4}, Lcom/igg/sdk/service/IGGAppConfigService;->load(Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 75
    :goto_0
    return-void

    .line 70
    :catch_0
    move-exception v0

    .line 72
    .local v0, "ex":Ljava/lang/Exception;
    const-string v1, "IGGService"

    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 73
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->EventCarnivalCallBackFailed:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method

.method public LoadGameConfig()V
    .locals 5

    .prologue
    .line 29
    :try_start_0
    new-instance v1, Lcom/igg/sdk/service/IGGAppConfigService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGAppConfigService;-><init>()V

    const-string v2, "server_config"

    sget-object v3, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->DEFAULT:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    new-instance v4, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$1;

    invoke-direct {v4, p0}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$1;-><init>(Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;)V

    invoke-virtual {v1, v2, v3, v4}, Lcom/igg/sdk/service/IGGAppConfigService;->load(Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 50
    :goto_0
    return-void

    .line 46
    :catch_0
    move-exception v0

    .line 48
    .local v0, "ex":Ljava/lang/Exception;
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->GameMaintanceCallBackFailed:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
