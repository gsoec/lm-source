.class public Lcom/igg/sdk/service/IGGLoginService;
.super Lcom/igg/sdk/service/IGGService;
.source "IGGLoginService.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/service/IGGLoginService$BindStateListener;,
        Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;
    }
.end annotation


# static fields
.field public static final ACCESS_KEY_VERSION:Ljava/lang/String; = "1.1"

.field private static final GUEST_LOGIN_GUSET_ID_EMPTY_ERROR:I = 0x30d42

.field private static final LOGIN_GAME_ID_EMPTY_ERROR:I = 0x30d46

.field private static final LOGIN_GUSET_ID_EMPTY_ERROR:I = 0x30d47

.field private static final LOGIN_RETURN_HANDLE_ERROR:I = 0x30d44

.field private static final LOGIN_THIRD_TOKEN_EMPTY_ERROR:I = 0x30d43

.field protected static final TAG:Ljava/lang/String; = "IGGLoginService"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 26
    invoke-direct {p0}, Lcom/igg/sdk/service/IGGService;-><init>()V

    return-void
.end method


# virtual methods
.method public amazonAccountBind(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    .locals 3
    .param p1, "accessKey"    # Ljava/lang/String;
    .param p2, "weChatAccessKey"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    .prologue
    .line 612
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 613
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "access_key"

    invoke-virtual {v0, v1, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 614
    const-string v1, "s_type"

    const-string v2, "Amazon"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 615
    const-string v1, "force"

    const-string v2, "0"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 616
    const-string v1, "3rd_access_key"

    invoke-virtual {v0, v1, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 618
    const-string v1, "m_game_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 620
    const-string v1, "/bind"

    invoke-static {v1}, Lcom/igg/sdk/IGGURLHelper;->getWeChatAPI(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    new-instance v2, Lcom/igg/sdk/service/IGGLoginService$11;

    invoke-direct {v2, p0, p3}, Lcom/igg/sdk/service/IGGLoginService$11;-><init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    invoke-super {p0, v1, v0, v2}, Lcom/igg/sdk/service/IGGService;->CGIGetRequestForFlatStruct(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 647
    return-void
.end method

.method public facebookLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    .locals 5
    .param p1, "logininfo"    # Lcom/igg/sdk/bean/IGGLoginInfo;
    .param p2, "listener"    # Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    .prologue
    .line 373
    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getKeepTime()I

    move-result v0

    .line 374
    .local v0, "keep_time":I
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 376
    .local v1, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v2, "platform_id"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getPlatformId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 377
    const-string v2, "platform_key"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getFacebook_token()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 378
    const-string v2, "s_type"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getType()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 379
    const-string v2, "m_game_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 380
    const-string v2, "keep_time"

    invoke-static {v0}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 382
    const-string v2, "GetToken"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "facebookLogin parameters"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 383
    const-string v2, "GetToken"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "facebookLogin getCGIURL = "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "/public/3rd_guest_login_igg_by_key"

    invoke-static {v4}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 384
    const-string v2, "/public/3rd_guest_login_igg_by_key"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/service/IGGLoginService$6;

    invoke-direct {v3, p0, p2}, Lcom/igg/sdk/service/IGGLoginService$6;-><init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    invoke-super {p0, v2, v1, v3}, Lcom/igg/sdk/service/IGGService;->CGIRequestForFlatStruct(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 410
    return-void
.end method

.method public getBindState(Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$BindStateListener;)V
    .locals 3
    .param p1, "IGGId"    # Ljava/lang/String;
    .param p2, "listener"    # Lcom/igg/sdk/service/IGGLoginService$BindStateListener;

    .prologue
    .line 128
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "/iggaccount/CheckHasBind"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "?m_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&m_game_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 130
    .local v0, "URL":Ljava/lang/String;
    const/4 v1, 0x0

    new-instance v2, Lcom/igg/sdk/service/IGGLoginService$2;

    invoke-direct {v2, p0, p2}, Lcom/igg/sdk/service/IGGLoginService$2;-><init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$BindStateListener;)V

    invoke-super {p0, v0, v1, v2}, Lcom/igg/sdk/service/IGGService;->CGIRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 148
    return-void
.end method

.method public guestLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    .locals 12
    .param p1, "logininfo"    # Lcom/igg/sdk/bean/IGGLoginInfo;
    .param p2, "listener"    # Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    .prologue
    const/4 v11, 0x0

    .line 56
    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getKeepTime()I

    move-result v2

    .line 57
    .local v2, "keep_time":I
    const-string v5, ""

    .line 59
    .local v5, "m_guest":Ljava/lang/String;
    :try_start_0
    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getGuest()Ljava/lang/String;

    move-result-object v8

    const-string v9, "utf-8"

    invoke-static {v8, v9}, Ljava/net/URLEncoder;->encode(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v5

    .line 64
    :goto_0
    const-string v8, "IGGLoginService"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "login m_guest:"

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getGuest()Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 69
    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getKey()Ljava/lang/String;

    move-result-object v6

    .line 70
    .local v6, "m_key":Ljava/lang/String;
    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getDeviceType()Ljava/lang/String;

    move-result-object v4

    .line 71
    .local v4, "m_device_type":Ljava/lang/String;
    new-instance v8, Lcom/igg/util/MD5;

    invoke-direct {v8}, Lcom/igg/util/MD5;-><init>()V

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getGuest()Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v10

    invoke-virtual {v10}, Lcom/igg/sdk/IGGSDK;->getSecretKey()Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Lcom/igg/util/MD5;->getMD5ofStr(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v8

    sget-object v9, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-virtual {v8, v9}, Ljava/lang/String;->toLowerCase(Ljava/util/Locale;)Ljava/lang/String;

    move-result-object v3

    .line 73
    .local v3, "m_data":Ljava/lang/String;
    const-string v7, ""

    .line 74
    .local v7, "str":Ljava/lang/String;
    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getCheckBindType()Ljava/lang/String;

    move-result-object v8

    if-eqz v8, :cond_0

    .line 75
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "&check_bind_type="

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getCheckBindType()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    .line 78
    :cond_0
    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getCheckAllBindType()Ljava/lang/String;

    move-result-object v8

    if-eqz v8, :cond_1

    .line 79
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "&getbindtype="

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getCheckAllBindType()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    .line 82
    :cond_1
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "/public/guest_user_login_igg"

    invoke-static {v9}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "?m_guest="

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "&m_key="

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "&m_data="

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "&m_device_type="

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "&keep_time="

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "&m_game_id="

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    .line 84
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v9

    invoke-virtual {v9}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 85
    .local v0, "URL":Ljava/lang/String;
    const-string v8, "IGGLoginService"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "login url:"

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 87
    new-instance v8, Lcom/igg/sdk/service/IGGLoginService$1;

    invoke-direct {v8, p0, p2}, Lcom/igg/sdk/service/IGGLoginService$1;-><init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    invoke-super {p0, v0, v11, v8}, Lcom/igg/sdk/service/IGGService;->CGIRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 119
    return-void

    .line 60
    .end local v0    # "URL":Ljava/lang/String;
    .end local v3    # "m_data":Ljava/lang/String;
    .end local v4    # "m_device_type":Ljava/lang/String;
    .end local v6    # "m_key":Ljava/lang/String;
    .end local v7    # "str":Ljava/lang/String;
    :catch_0
    move-exception v1

    .line 61
    .local v1, "e":Ljava/lang/Exception;
    new-instance v8, Ljava/lang/Exception;

    const-string v9, "Guest ID is null"

    invoke-direct {v8, v9}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const v9, 0x30d42

    invoke-static {v8, v9}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v8

    invoke-interface {p2, v8, v11}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    goto/16 :goto_0
.end method

.method public keyLogin(Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    .locals 4
    .param p1, "key"    # Ljava/lang/String;
    .param p2, "listener"    # Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    .prologue
    .line 157
    move-object v1, p1

    .line 159
    .local v1, "signedkey":Ljava/lang/String;
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "/public/get_iggid_by_key"

    invoke-static {v3}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "?signed_key="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "&version="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "1.1"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 161
    .local v0, "URL":Ljava/lang/String;
    const/4 v2, 0x0

    new-instance v3, Lcom/igg/sdk/service/IGGLoginService$3;

    invoke-direct {v3, p0, p2}, Lcom/igg/sdk/service/IGGLoginService$3;-><init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    invoke-super {p0, v0, v2, v3}, Lcom/igg/sdk/service/IGGService;->CGIRequestForFlatStruct(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 194
    return-void
.end method

.method public thirdAccountBind(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    .locals 3
    .param p1, "accessKey"    # Ljava/lang/String;
    .param p2, "thirdType"    # Ljava/lang/String;
    .param p3, "thirdAccessKey"    # Ljava/lang/String;
    .param p4, "listener"    # Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    .prologue
    .line 205
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 206
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "access_key"

    invoke-virtual {v0, v1, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 207
    const-string v1, "s_type"

    invoke-virtual {v0, v1, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 208
    const-string v1, "3rd_access_key"

    invoke-virtual {v0, v1, p3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 209
    const-string v1, "m_game_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 211
    const-string v1, "/public/GuestBind3rdByKey"

    invoke-static {v1}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    new-instance v2, Lcom/igg/sdk/service/IGGLoginService$4;

    invoke-direct {v2, p0, p4}, Lcom/igg/sdk/service/IGGLoginService$4;-><init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    invoke-super {p0, v1, v0, v2}, Lcom/igg/sdk/service/IGGService;->CGIRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 238
    return-void
.end method

.method public thirdAccountLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    .locals 24
    .param p1, "loginInfo"    # Lcom/igg/sdk/bean/IGGLoginInfo;
    .param p2, "listener"    # Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 250
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getGooglePlusToken()Ljava/lang/String;

    move-result-object v13

    .line 252
    .local v13, "googlePlusToken":Ljava/lang/String;
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getGuest()Ljava/lang/String;

    move-result-object v7

    .line 253
    .local v7, "deviceRegisterIds":Ljava/lang/String;
    const-string v21, "IGGLoginService"

    new-instance v22, Ljava/lang/StringBuilder;

    invoke-direct/range {v22 .. v22}, Ljava/lang/StringBuilder;-><init>()V

    const-string v23, "deviceRegisterIds=======>"

    invoke-virtual/range {v22 .. v23}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v22

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v23

    invoke-virtual/range {v23 .. v23}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v23

    invoke-virtual/range {v22 .. v23}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v22

    invoke-virtual/range {v22 .. v22}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v22

    invoke-static/range {v21 .. v22}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 254
    new-instance v8, Lcom/igg/sdk/IGGDeviceStorage;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v21

    invoke-virtual/range {v21 .. v21}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v21

    move-object/from16 v0, v21

    invoke-direct {v8, v0}, Lcom/igg/sdk/IGGDeviceStorage;-><init>(Landroid/content/Context;)V

    .line 255
    .local v8, "deviceStorageContent":Lcom/igg/sdk/IGGDeviceStorage;
    invoke-virtual {v8}, Lcom/igg/sdk/IGGDeviceStorage;->currentDeviceUID()Ljava/lang/String;

    move-result-object v20

    .line 256
    .local v20, "stroageDeviceUIDStr":Ljava/lang/String;
    if-eqz v7, :cond_0

    const-string v21, ""

    move-object/from16 v0, v21

    invoke-virtual {v7, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v21

    if-eqz v21, :cond_1

    .line 257
    :cond_0
    move-object/from16 v7, v20

    .line 260
    :cond_1
    const-string v10, ""

    .line 261
    .local v10, "deviceid":Ljava/lang/String;
    const-string v11, ""

    .line 262
    .local v11, "gaid":Ljava/lang/String;
    const-string v18, ""

    .line 263
    .local v18, "mac":Ljava/lang/String;
    const-string v4, ""

    .line 264
    .local v4, "aid":Ljava/lang/String;
    const-string v21, ","

    move-object/from16 v0, v21

    invoke-virtual {v7, v0}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v21

    const/16 v22, -0x1

    move/from16 v0, v21

    move/from16 v1, v22

    if-eq v0, v1, :cond_9

    .line 265
    const-string v21, ","

    move-object/from16 v0, v21

    invoke-virtual {v7, v0}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v5

    .line 266
    .local v5, "ary":[Ljava/lang/String;
    const/4 v15, 0x0

    .local v15, "i":I
    :goto_0
    array-length v0, v5

    move/from16 v21, v0

    move/from16 v0, v21

    if-ge v15, v0, :cond_5

    .line 267
    aget-object v21, v5, v15

    const-string v22, "="

    invoke-virtual/range {v21 .. v22}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v21

    const/16 v22, 0x0

    aget-object v21, v21, v22

    const-string v22, "gaid"

    invoke-virtual/range {v21 .. v22}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v21

    if-eqz v21, :cond_2

    .line 268
    aget-object v21, v5, v15

    const-string v22, "="

    invoke-virtual/range {v21 .. v22}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v21

    const/16 v22, 0x1

    aget-object v11, v21, v22

    .line 271
    :cond_2
    aget-object v21, v5, v15

    const-string v22, "="

    invoke-virtual/range {v21 .. v22}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v21

    const/16 v22, 0x0

    aget-object v21, v21, v22

    const-string v22, "mac"

    invoke-virtual/range {v21 .. v22}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v21

    if-eqz v21, :cond_3

    .line 272
    aget-object v21, v5, v15

    const-string v22, "="

    invoke-virtual/range {v21 .. v22}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v21

    const/16 v22, 0x1

    aget-object v18, v21, v22

    .line 275
    :cond_3
    aget-object v21, v5, v15

    const-string v22, "="

    invoke-virtual/range {v21 .. v22}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v21

    const/16 v22, 0x0

    aget-object v21, v21, v22

    const-string v22, "aid"

    invoke-virtual/range {v21 .. v22}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v21

    if-eqz v21, :cond_4

    .line 276
    aget-object v21, v5, v15

    const-string v22, "="

    invoke-virtual/range {v21 .. v22}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v21

    const/16 v22, 0x1

    aget-object v4, v21, v22

    .line 266
    :cond_4
    add-int/lit8 v15, v15, 0x1

    goto :goto_0

    .line 280
    :cond_5
    const-string v21, ""

    move-object/from16 v0, v21

    invoke-virtual {v11, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v21

    if-eqz v21, :cond_8

    .line 281
    const-string v21, ""

    move-object/from16 v0, v18

    move-object/from16 v1, v21

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v21

    if-eqz v21, :cond_7

    .line 282
    move-object v10, v4

    .line 293
    .end local v5    # "ary":[Ljava/lang/String;
    .end local v15    # "i":I
    :goto_1
    const-string v21, "IGGLoginService"

    new-instance v22, Ljava/lang/StringBuilder;

    invoke-direct/range {v22 .. v22}, Ljava/lang/StringBuilder;-><init>()V

    const-string v23, "deviceId=======>"

    invoke-virtual/range {v22 .. v23}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v22

    move-object/from16 v0, v22

    invoke-virtual {v0, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v22

    invoke-virtual/range {v22 .. v22}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v22

    invoke-static/range {v21 .. v22}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 295
    move-object v14, v10

    .line 296
    .local v14, "guest":Ljava/lang/String;
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getKey()Ljava/lang/String;

    move-result-object v17

    .line 298
    .local v17, "key":Ljava/lang/String;
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getDeviceType()Ljava/lang/String;

    move-result-object v9

    .line 299
    .local v9, "deviceType":Ljava/lang/String;
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v21

    invoke-virtual/range {v21 .. v21}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v12

    .line 300
    .local v12, "gameId":Ljava/lang/String;
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getKeepTime()I

    move-result v16

    .line 302
    .local v16, "keepTime":I
    new-instance v21, Lcom/igg/util/MD5;

    invoke-direct/range {v21 .. v21}, Lcom/igg/util/MD5;-><init>()V

    new-instance v22, Ljava/lang/StringBuilder;

    invoke-direct/range {v22 .. v22}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v0, v22

    invoke-virtual {v0, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v22

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v23

    invoke-virtual/range {v23 .. v23}, Lcom/igg/sdk/IGGSDK;->getSecretKey()Ljava/lang/String;

    move-result-object v23

    invoke-virtual/range {v22 .. v23}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v22

    move-object/from16 v0, v22

    move-object/from16 v1, v17

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v22

    move-object/from16 v0, v22

    invoke-virtual {v0, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v22

    invoke-virtual/range {v22 .. v22}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v22

    invoke-virtual/range {v21 .. v22}, Lcom/igg/util/MD5;->getMD5ofStr(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v21

    sget-object v22, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-virtual/range {v21 .. v22}, Ljava/lang/String;->toLowerCase(Ljava/util/Locale;)Ljava/lang/String;

    move-result-object v6

    .line 304
    .local v6, "data":Ljava/lang/String;
    if-eqz v13, :cond_6

    const-string v21, ""

    move-object/from16 v0, v21

    invoke-virtual {v13, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v21

    if-eqz v21, :cond_a

    .line 305
    :cond_6
    const-string v21, "IGGLoginService"

    const-string v22, "100001#Error parameter:m_google_plus_token"

    invoke-static/range {v21 .. v22}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 307
    new-instance v21, Ljava/lang/Exception;

    const-string v22, "Google token is null"

    invoke-direct/range {v21 .. v22}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const v22, 0x30d43

    invoke-static/range {v21 .. v22}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v21

    const/16 v22, 0x0

    move-object/from16 v0, p2

    move-object/from16 v1, v21

    move-object/from16 v2, v22

    invoke-interface {v0, v1, v2}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    .line 364
    :goto_2
    return-void

    .line 284
    .end local v6    # "data":Ljava/lang/String;
    .end local v9    # "deviceType":Ljava/lang/String;
    .end local v12    # "gameId":Ljava/lang/String;
    .end local v14    # "guest":Ljava/lang/String;
    .end local v16    # "keepTime":I
    .end local v17    # "key":Ljava/lang/String;
    .restart local v5    # "ary":[Ljava/lang/String;
    .restart local v15    # "i":I
    :cond_7
    move-object/from16 v10, v18

    goto/16 :goto_1

    .line 287
    :cond_8
    move-object v10, v11

    goto/16 :goto_1

    .line 290
    .end local v5    # "ary":[Ljava/lang/String;
    .end local v15    # "i":I
    :cond_9
    const-string v21, "="

    move-object/from16 v0, v21

    invoke-virtual {v7, v0}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v21

    const/16 v22, 0x1

    aget-object v10, v21, v22

    goto/16 :goto_1

    .line 311
    .restart local v6    # "data":Ljava/lang/String;
    .restart local v9    # "deviceType":Ljava/lang/String;
    .restart local v12    # "gameId":Ljava/lang/String;
    .restart local v14    # "guest":Ljava/lang/String;
    .restart local v16    # "keepTime":I
    .restart local v17    # "key":Ljava/lang/String;
    :cond_a
    if-eqz v14, :cond_b

    const-string v21, ""

    move-object/from16 v0, v21

    invoke-virtual {v14, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v21

    if-eqz v21, :cond_c

    .line 312
    :cond_b
    const-string v21, "IGGLoginService"

    const-string v22, "100007#Error parameter:m_guest"

    invoke-static/range {v21 .. v22}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 314
    new-instance v21, Ljava/lang/Exception;

    const-string v22, "Guest ID is null"

    invoke-direct/range {v21 .. v22}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const v22, 0x30d47

    invoke-static/range {v21 .. v22}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v21

    const/16 v22, 0x0

    move-object/from16 v0, p2

    move-object/from16 v1, v21

    move-object/from16 v2, v22

    invoke-interface {v0, v1, v2}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    goto :goto_2

    .line 318
    :cond_c
    if-eqz v12, :cond_d

    const-string v21, ""

    move-object/from16 v0, v21

    invoke-virtual {v12, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v21

    if-eqz v21, :cond_e

    .line 319
    :cond_d
    const-string v21, "IGGLoginService"

    const-string v22, "100006#Error parameter:m_game_id."

    invoke-static/range {v21 .. v22}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 321
    new-instance v21, Ljava/lang/Exception;

    const-string v22, "Game ID is null"

    invoke-direct/range {v21 .. v22}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const v22, 0x30d46

    invoke-static/range {v21 .. v22}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v21

    const/16 v22, 0x0

    move-object/from16 v0, p2

    move-object/from16 v1, v21

    move-object/from16 v2, v22

    invoke-interface {v0, v1, v2}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    goto :goto_2

    .line 325
    :cond_e
    new-instance v19, Ljava/util/HashMap;

    invoke-direct/range {v19 .. v19}, Ljava/util/HashMap;-><init>()V

    .line 326
    .local v19, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v21, "m_google_plus_token"

    move-object/from16 v0, v19

    move-object/from16 v1, v21

    invoke-virtual {v0, v1, v13}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 327
    const-string v21, "m_guest"

    move-object/from16 v0, v19

    move-object/from16 v1, v21

    invoke-virtual {v0, v1, v14}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 328
    const-string v21, "m_key"

    move-object/from16 v0, v19

    move-object/from16 v1, v21

    move-object/from16 v2, v17

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 329
    const-string v21, "m_data"

    move-object/from16 v0, v19

    move-object/from16 v1, v21

    invoke-virtual {v0, v1, v6}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 330
    const-string v21, "m_device_type"

    move-object/from16 v0, v19

    move-object/from16 v1, v21

    invoke-virtual {v0, v1, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 331
    const-string v21, "m_game_id"

    move-object/from16 v0, v19

    move-object/from16 v1, v21

    invoke-virtual {v0, v1, v12}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 332
    const-string v21, "keep_time"

    invoke-static/range {v16 .. v16}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v22

    move-object/from16 v0, v19

    move-object/from16 v1, v21

    move-object/from16 v2, v22

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 340
    const-string v21, "/public/google_plus_login_igg"

    invoke-static/range {v21 .. v21}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v21

    new-instance v22, Lcom/igg/sdk/service/IGGLoginService$5;

    move-object/from16 v0, v22

    move-object/from16 v1, p0

    move-object/from16 v2, p2

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/service/IGGLoginService$5;-><init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    move-object/from16 v0, p0

    move-object/from16 v1, v21

    move-object/from16 v2, v19

    move-object/from16 v3, v22

    invoke-virtual {v0, v1, v2, v3}, Lcom/igg/sdk/service/IGGLoginService;->CGIRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    goto/16 :goto_2
.end method

.method public thirdAmazonAccountLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    .locals 4
    .param p1, "loginInfo"    # Lcom/igg/sdk/bean/IGGLoginInfo;
    .param p2, "listener"    # Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 568
    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getAuthCode()Ljava/lang/String;

    move-result-object v0

    .line 569
    .local v0, "authCode":Ljava/lang/String;
    if-eqz v0, :cond_0

    const-string v2, ""

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_1

    .line 570
    :cond_0
    new-instance v2, Ljava/lang/Exception;

    const-string v3, "Error parameter:Amazon authCode"

    invoke-direct {v2, v3}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v2

    .line 573
    :cond_1
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 574
    .local v1, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v2, "platform_key"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getAuthCode()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 575
    const-string v2, "s_type"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getType()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 576
    const-string v2, "m_game_id"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getGameId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 577
    const-string v2, "keep_time"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getKeepTime()I

    move-result v3

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 579
    const-string v2, "/auth"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getWeChatAPI(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/service/IGGLoginService$10;

    invoke-direct {v3, p0, p2}, Lcom/igg/sdk/service/IGGLoginService$10;-><init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    invoke-super {p0, v2, v1, v3}, Lcom/igg/sdk/service/IGGService;->CGIGetRequestForFlatStruct(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 604
    return-void
.end method

.method public thirdFacebookAccountLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    .locals 5
    .param p1, "loginInfo"    # Lcom/igg/sdk/bean/IGGLoginInfo;
    .param p2, "listener"    # Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 420
    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getRd_access_key()Ljava/lang/String;

    move-result-object v2

    .line 421
    .local v2, "platform_key":Ljava/lang/String;
    if-eqz v2, :cond_0

    const-string v3, ""

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_1

    .line 422
    :cond_0
    new-instance v3, Ljava/lang/Exception;

    const-string v4, "100005#platform_key is null"

    invoke-direct {v3, v4}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v3

    .line 425
    :cond_1
    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getPlatformId()Ljava/lang/String;

    move-result-object v1

    .line 426
    .local v1, "platform_id":Ljava/lang/String;
    if-eqz v1, :cond_2

    const-string v3, ""

    invoke-virtual {v1, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_3

    .line 427
    :cond_2
    new-instance v3, Ljava/lang/Exception;

    const-string v4, "100001#platform_id is null"

    invoke-direct {v3, v4}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v3

    .line 430
    :cond_3
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 431
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v3, "platform_id"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getPlatformId()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v0, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 432
    const-string v3, "platform_key"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getRd_access_key()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v0, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 433
    const-string v3, "s_type"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getType()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v0, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 434
    const-string v3, "m_game_id"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getGameId()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v0, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 435
    const-string v3, "keep_time"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getKeepTime()I

    move-result v4

    invoke-static {v4}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v0, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 436
    const-string v3, "facebookinfo"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getFlag()I

    move-result v4

    invoke-static {v4}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v0, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 438
    const-string v3, "/public/3rd_guest_login_igg_by_key"

    invoke-static {v3}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    new-instance v4, Lcom/igg/sdk/service/IGGLoginService$7;

    invoke-direct {v4, p0, p2}, Lcom/igg/sdk/service/IGGLoginService$7;-><init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    invoke-super {p0, v3, v0, v4}, Lcom/igg/sdk/service/IGGService;->CGIRequestForFlatStruct(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 461
    return-void
.end method

.method public thirdWechatAccountLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    .locals 4
    .param p1, "loginInfo"    # Lcom/igg/sdk/bean/IGGLoginInfo;
    .param p2, "listener"    # Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 471
    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getAuthCode()Ljava/lang/String;

    move-result-object v0

    .line 472
    .local v0, "authCode":Ljava/lang/String;
    if-eqz v0, :cond_0

    const-string v2, ""

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_1

    .line 473
    :cond_0
    new-instance v2, Ljava/lang/Exception;

    const-string v3, "Error parameter:wechat authCode"

    invoke-direct {v2, v3}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v2

    .line 476
    :cond_1
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 477
    .local v1, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v2, "platform_key"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getAuthCode()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 478
    const-string v2, "s_type"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getType()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 479
    const-string v2, "m_game_id"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getGameId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 480
    const-string v2, "keep_time"

    invoke-virtual {p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->getKeepTime()I

    move-result v3

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 482
    const-string v2, "/auth"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getWeChatAPI(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/service/IGGLoginService$8;

    invoke-direct {v3, p0, p2}, Lcom/igg/sdk/service/IGGLoginService$8;-><init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    invoke-super {p0, v2, v1, v3}, Lcom/igg/sdk/service/IGGService;->CGIGetRequestForFlatStruct(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 507
    return-void
.end method

.method public weChatAccountBind(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    .locals 3
    .param p1, "accessKey"    # Ljava/lang/String;
    .param p2, "weChatAccessKey"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    .prologue
    .line 515
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 516
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "access_key"

    invoke-virtual {v0, v1, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 517
    const-string v1, "s_type"

    const-string v2, "WeChat"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 518
    const-string v1, "force"

    const-string v2, "0"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 519
    const-string v1, "3rd_access_key"

    invoke-virtual {v0, v1, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 521
    const-string v1, "m_game_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 523
    const-string v1, "/bind"

    invoke-static {v1}, Lcom/igg/sdk/IGGURLHelper;->getWeChatAPI(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    new-instance v2, Lcom/igg/sdk/service/IGGLoginService$9;

    invoke-direct {v2, p0, p3}, Lcom/igg/sdk/service/IGGLoginService$9;-><init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    invoke-super {p0, v1, v0, v2}, Lcom/igg/sdk/service/IGGService;->CGIGetRequestForFlatStruct(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 558
    return-void
.end method
