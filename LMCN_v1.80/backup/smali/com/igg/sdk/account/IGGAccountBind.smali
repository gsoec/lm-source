.class public Lcom/igg/sdk/account/IGGAccountBind;
.super Ljava/lang/Object;
.source "IGGAccountBind.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;,
        Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;,
        Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;,
        Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;,
        Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;,
        Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;,
        Lcom/igg/sdk/account/IGGAccountBind$BindListener;
    }
.end annotation


# static fields
.field public static final REQUEST_CODE_GOOGLEAUTHEXCEPTION:I = 0x3eb

.field public static final REQUEST_CODE_RECOVER_FROM_AUTH_ERROR:I = 0x3e9

.field public static final REQUEST_CODE_RECOVER_FROM_PLAY_SERVICES_ERROR:I = 0x3ea

.field private static final TAG:Ljava/lang/String; = "IGGAccountBind"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 31
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static synthetic access$000(Lcom/igg/sdk/account/IGGAccountBind;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/account/IGGAccountBind;
    .param p1, "x1"    # Ljava/lang/String;
    .param p2, "x2"    # Ljava/lang/String;
    .param p3, "x3"    # Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    .prologue
    .line 31
    invoke-direct {p0, p1, p2, p3}, Lcom/igg/sdk/account/IGGAccountBind;->handleThirdBind(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V

    return-void
.end method

.method private handleThirdBind(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V
    .locals 3
    .param p1, "thirdType"    # Ljava/lang/String;
    .param p2, "thirdAccessKey"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    .prologue
    .line 538
    new-instance v0, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 539
    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v1

    new-instance v2, Lcom/igg/sdk/account/IGGAccountBind$6;

    invoke-direct {v2, p0, p3}, Lcom/igg/sdk/account/IGGAccountBind$6;-><init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V

    .line 538
    invoke-virtual {v0, v1, p1, p2, v2}, Lcom/igg/sdk/service/IGGLoginService;->thirdAccountBind(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    .line 572
    return-void
.end method


# virtual methods
.method public bindAssessKeytoDevice(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;)V
    .locals 8
    .param p1, "decevice_key"    # Ljava/lang/String;
    .param p2, "b_key"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;

    .prologue
    .line 215
    const-string v4, "/public/BindToIggByKey"

    invoke-static {v4}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 216
    .local v0, "API":Ljava/lang/String;
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v6

    invoke-virtual {v4, v6, v7}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ""

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 217
    .local v2, "m_key":Ljava/lang/String;
    new-instance v4, Lcom/igg/util/MD5;

    invoke-direct {v4}, Lcom/igg/util/MD5;-><init>()V

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v6, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v6}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    .line 218
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v6

    invoke-virtual {v6}, Lcom/igg/sdk/IGGSDK;->getEnhancedSecretKey()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "guest"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    .line 217
    invoke-virtual {v4, v5}, Lcom/igg/util/MD5;->getMD5ofStr(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    sget-object v5, Ljava/util/Locale;->US:Ljava/util/Locale;

    .line 218
    invoke-virtual {v4, v5}, Ljava/lang/String;->toLowerCase(Ljava/util/Locale;)Ljava/lang/String;

    move-result-object v1

    .line 219
    .local v1, "m_data":Ljava/lang/String;
    new-instance v3, Ljava/util/HashMap;

    invoke-direct {v3}, Ljava/util/HashMap;-><init>()V

    .line 220
    .local v3, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v4, "signed_key"

    sget-object v5, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v5}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v3, v4, v5}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 221
    const-string v4, "b_key"

    invoke-virtual {v3, v4, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 222
    const-string v4, "s_type"

    const-string v5, "guest"

    invoke-virtual {v3, v4, v5}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 223
    const-string v4, "m_key"

    invoke-virtual {v3, v4, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 224
    const-string v4, "m_data"

    invoke-virtual {v3, v4, v1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 225
    const-string v4, "m_game_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v5

    invoke-virtual {v5}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v3, v4, v5}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 227
    const-string v4, "IGGAccountBind"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, " b_key:"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 234
    new-instance v4, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v4}, Lcom/igg/sdk/service/IGGService;-><init>()V

    new-instance v5, Lcom/igg/sdk/account/IGGAccountBind$2;

    invoke-direct {v5, p0, p3}, Lcom/igg/sdk/account/IGGAccountBind$2;-><init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;)V

    invoke-virtual {v4, v0, v3, v5}, Lcom/igg/sdk/service/IGGService;->CGIGeneralRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 329
    return-void
.end method

.method public bindToAmazonCount(Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;)V
    .locals 3
    .param p1, "amazonAccessKey"    # Ljava/lang/String;
    .param p2, "listener"    # Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;

    .prologue
    .line 648
    new-instance v0, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 649
    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v1

    new-instance v2, Lcom/igg/sdk/account/IGGAccountBind$8;

    invoke-direct {v2, p0, p2}, Lcom/igg/sdk/account/IGGAccountBind$8;-><init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;)V

    .line 648
    invoke-virtual {v0, v1, p1, v2}, Lcom/igg/sdk/service/IGGLoginService;->amazonAccountBind(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    .line 696
    return-void
.end method

.method public bindToExistingAccount(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;)V
    .locals 4
    .param p1, "userName"    # Ljava/lang/String;
    .param p2, "password"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;

    .prologue
    .line 340
    const-string v2, "/public/GuestBindParentAccountByKey"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 342
    .local v0, "API":Ljava/lang/String;
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 343
    .local v1, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v2, "access_key"

    sget-object v3, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v3}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 344
    const-string v2, "m_game_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 345
    const-string v2, "m_device_type"

    sget-object v3, Landroid/os/Build;->MODEL:Ljava/lang/String;

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 346
    const-string v2, "m_name"

    invoke-virtual {v1, v2, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 347
    const-string v2, "m_pass"

    invoke-virtual {v1, v2, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 349
    new-instance v2, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v2}, Lcom/igg/sdk/service/IGGService;-><init>()V

    new-instance v3, Lcom/igg/sdk/account/IGGAccountBind$3;

    invoke-direct {v3, p0, p3}, Lcom/igg/sdk/account/IGGAccountBind$3;-><init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;)V

    invoke-virtual {v2, v0, v1, v3}, Lcom/igg/sdk/service/IGGService;->CGIRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 405
    return-void
.end method

.method public bindToGooglePlay(Ljava/lang/String;Landroid/app/Activity;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V
    .locals 4
    .param p1, "email"    # Ljava/lang/String;
    .param p2, "activity"    # Landroid/app/Activity;
    .param p3, "listener"    # Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    .prologue
    .line 484
    new-instance v0, Lcom/igg/sdk/account/IGGAccountBind$5;

    invoke-direct {v0, p0, p1, p2, p3}, Lcom/igg/sdk/account/IGGAccountBind$5;-><init>(Lcom/igg/sdk/account/IGGAccountBind;Ljava/lang/String;Landroid/app/Activity;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V

    .line 527
    .local v0, "task":Landroid/os/AsyncTask;, "Landroid/os/AsyncTask<Ljava/lang/Object;Ljava/lang/Integer;Ljava/lang/Object;>;"
    const/4 v1, 0x1

    new-array v2, v1, [Ljava/lang/Object;

    const/4 v3, 0x0

    const/4 v1, 0x0

    check-cast v1, Ljava/lang/Void;

    aput-object v1, v2, v3

    invoke-virtual {v0, v2}, Landroid/os/AsyncTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    .line 528
    return-void
.end method

.method public bindToNewAccount(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;)V
    .locals 4
    .param p1, "userName"    # Ljava/lang/String;
    .param p2, "password"    # Ljava/lang/String;
    .param p3, "email"    # Ljava/lang/String;
    .param p4, "listener"    # Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;

    .prologue
    .line 416
    const-string v2, "/public/CreateIGGAccountByKey"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 418
    .local v0, "API":Ljava/lang/String;
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 419
    .local v1, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v2, "access_key"

    sget-object v3, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v3}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 420
    const-string v2, "m_game_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 421
    const-string v2, "m_name"

    invoke-virtual {v1, v2, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 422
    const-string v2, "m_pass"

    invoke-virtual {v1, v2, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 423
    const-string v2, "m_pass2"

    invoke-virtual {v1, v2, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 424
    const-string v2, "email"

    invoke-virtual {v1, v2, p3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 426
    new-instance v2, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v2}, Lcom/igg/sdk/service/IGGService;-><init>()V

    new-instance v3, Lcom/igg/sdk/account/IGGAccountBind$4;

    invoke-direct {v3, p0, p4}, Lcom/igg/sdk/account/IGGAccountBind$4;-><init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;)V

    invoke-virtual {v2, v0, v1, v3}, Lcom/igg/sdk/service/IGGService;->CGIRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 474
    return-void
.end method

.method public bindToWeChat(Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;)V
    .locals 3
    .param p1, "weChatAccessKey"    # Ljava/lang/String;
    .param p2, "listener"    # Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;

    .prologue
    .line 582
    new-instance v0, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 583
    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v1

    new-instance v2, Lcom/igg/sdk/account/IGGAccountBind$7;

    invoke-direct {v2, p0, p2}, Lcom/igg/sdk/account/IGGAccountBind$7;-><init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;)V

    .line 582
    invoke-virtual {v0, v1, p1, v2}, Lcom/igg/sdk/service/IGGLoginService;->weChatAccountBind(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    .line 637
    return-void
.end method

.method public bindVKAccount(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;)V
    .locals 4
    .param p1, "platformKey"    # Ljava/lang/String;
    .param p2, "platformId"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;

    .prologue
    .line 744
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 745
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "access_key"

    sget-object v2, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v2}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 746
    const-string v1, "platform_key"

    invoke-virtual {v0, v1, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 747
    const-string v1, "platform_id"

    invoke-virtual {v0, v1, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 748
    const-string v1, "m_game_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 750
    new-instance v1, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGService;-><init>()V

    const-string v2, "/vk/connect"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getWeChatAPI(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/account/IGGAccountBind$10;

    invoke-direct {v3, p0, p3}, Lcom/igg/sdk/account/IGGAccountBind$10;-><init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;)V

    invoke-virtual {v1, v2, v0, v3}, Lcom/igg/sdk/service/IGGService;->CGIGeneralGetRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 799
    return-void
.end method

.method public checkDeviceIDBind(Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;)V
    .locals 5
    .param p1, "deceviceID"    # Ljava/lang/String;
    .param p2, "listener"    # Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;

    .prologue
    .line 162
    const-string v2, "/public/GetMIDBy3rdId"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 163
    .local v0, "API":Ljava/lang/String;
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 164
    .local v1, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v2, "IGGAccountBind"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "checkDeviceIDBind b_key:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 165
    const-string v2, "b_key"

    invoke-virtual {v1, v2, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 166
    const-string v2, "s_type"

    const-string v3, "guest"

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 167
    new-instance v2, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v2}, Lcom/igg/sdk/service/IGGService;-><init>()V

    new-instance v3, Lcom/igg/sdk/account/IGGAccountBind$1;

    invoke-direct {v3, p0, p2, p1}, Lcom/igg/sdk/account/IGGAccountBind$1;-><init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;Ljava/lang/String;)V

    invoke-virtual {v2, v0, v1, v3}, Lcom/igg/sdk/service/IGGService;->CGIGeneralRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 205
    return-void
.end method

.method public facebookBind(Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V
    .locals 4
    .param p1, "thirdAccessKey"    # Ljava/lang/String;
    .param p2, "listener"    # Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    .prologue
    .line 706
    new-instance v0, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 707
    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v1

    const-string v2, "Facebook"

    new-instance v3, Lcom/igg/sdk/account/IGGAccountBind$9;

    invoke-direct {v3, p0, p2}, Lcom/igg/sdk/account/IGGAccountBind$9;-><init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V

    .line 706
    invoke-virtual {v0, v1, v2, p1, v3}, Lcom/igg/sdk/service/IGGLoginService;->thirdAccountBind(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    .line 741
    return-void
.end method
