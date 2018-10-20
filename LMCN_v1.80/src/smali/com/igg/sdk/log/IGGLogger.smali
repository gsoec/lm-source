.class public Lcom/igg/sdk/log/IGGLogger;
.super Ljava/lang/Object;
.source "IGGLogger.java"


# instance fields
.field private idc:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;


# direct methods
.method public constructor <init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V
    .locals 0
    .param p1, "idc"    # Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .prologue
    .line 32
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 33
    iput-object p1, p0, Lcom/igg/sdk/log/IGGLogger;->idc:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .line 34
    return-void
.end method


# virtual methods
.method public adLog(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/log/listener/LoggerListener;)V
    .locals 4
    .param p1, "source"    # Ljava/lang/String;
    .param p2, "ADId"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/log/listener/LoggerListener;

    .prologue
    .line 87
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 89
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "g_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 90
    const-string v1, "userid"

    sget-object v2, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 91
    const-string v1, "channel"

    invoke-virtual {v0, v1, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 92
    const-string v1, "ADId"

    invoke-virtual {v0, v1, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 94
    new-instance v1, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGService;-><init>()V

    iget-object v2, p0, Lcom/igg/sdk/log/IGGLogger;->idc:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-static {v2}, Lcom/igg/sdk/log/IGGLoggerHelper;->ADXLogAPI(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/log/IGGLogger$2;

    invoke-direct {v3, p0, p3}, Lcom/igg/sdk/log/IGGLogger$2;-><init>(Lcom/igg/sdk/log/IGGLogger;Lcom/igg/sdk/log/listener/LoggerListener;)V

    invoke-virtual {v1, v2, v0, v3}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 117
    return-void
.end method

.method public loginLog(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/log/listener/LoggerListener;)V
    .locals 5
    .param p1, "adStr"    # Ljava/lang/String;
    .param p2, "from"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/log/listener/LoggerListener;

    .prologue
    .line 44
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v2

    invoke-static {v2}, Lcom/igg/util/DeviceUtil;->getLocalMacAddress(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v0

    .line 46
    .local v0, "MAC":Ljava/lang/String;
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 47
    .local v1, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v2, "g_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 48
    const-string v2, "userid"

    sget-object v3, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v3}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 49
    const-string v2, "ad_str"

    invoke-virtual {v1, v2, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 50
    const-string v2, "from"

    invoke-virtual {v1, v2, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 51
    const-string v2, "mac"

    invoke-virtual {v1, v2, v0}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 53
    new-instance v2, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v2}, Lcom/igg/sdk/service/IGGService;-><init>()V

    iget-object v3, p0, Lcom/igg/sdk/log/IGGLogger;->idc:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-static {v3}, Lcom/igg/sdk/log/IGGLoggerHelper;->loginLogAPI(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)Ljava/lang/String;

    move-result-object v3

    new-instance v4, Lcom/igg/sdk/log/IGGLogger$1;

    invoke-direct {v4, p0, p3}, Lcom/igg/sdk/log/IGGLogger$1;-><init>(Lcom/igg/sdk/log/IGGLogger;Lcom/igg/sdk/log/listener/LoggerListener;)V

    invoke-virtual {v2, v3, v1, v4}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 76
    return-void
.end method
