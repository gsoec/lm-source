.class public Lcom/igg/android/wegamers/auth/WeGamersIMAuth;
.super Ljava/lang/Object;
.source "WeGamersIMAuth.java"


# static fields
.field private static mAuthResponse:Lcom/igg/android/wegamers/auth/IAuthResponse;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 16
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private static authInfo2Json(ILcom/igg/android/wegamers/auth/AuthInfo;)Ljava/lang/String;
    .locals 10
    .param p0, "iRet"    # I
    .param p1, "authInfo"    # Lcom/igg/android/wegamers/auth/AuthInfo;

    .prologue
    .line 41
    const/4 v0, 0x0

    .line 42
    .local v0, "content":Ljava/lang/String;
    new-instance v5, Lorg/json/JSONObject;

    invoke-direct {v5}, Lorg/json/JSONObject;-><init>()V

    .line 44
    .local v5, "jsonObject":Lorg/json/JSONObject;
    const-string v7, ""

    .line 45
    .local v7, "token":Ljava/lang/String;
    const-string v8, ""

    .line 46
    .local v8, "userIggId":Ljava/lang/String;
    const-string v4, ""

    .line 47
    .local v4, "gameUserId":Ljava/lang/String;
    const-string v3, ""

    .line 49
    .local v3, "gameId":Ljava/lang/String;
    if-eqz p1, :cond_0

    .line 50
    invoke-virtual {p1}, Lcom/igg/android/wegamers/auth/AuthInfo;->getToken()Ljava/lang/String;

    move-result-object v7

    .line 51
    invoke-virtual {p1}, Lcom/igg/android/wegamers/auth/AuthInfo;->getUserIggId()Ljava/lang/String;

    move-result-object v8

    .line 52
    invoke-virtual {p1}, Lcom/igg/android/wegamers/auth/AuthInfo;->getGameUserId()Ljava/lang/String;

    move-result-object v4

    .line 53
    invoke-virtual {p1}, Lcom/igg/android/wegamers/auth/AuthInfo;->getGameId()Ljava/lang/String;

    move-result-object v3

    .line 56
    :cond_0
    :try_start_0
    const-string v9, "ERR_CODE"

    invoke-virtual {v5, v9, p0}, Lorg/json/JSONObject;->put(Ljava/lang/String;I)Lorg/json/JSONObject;

    .line 57
    const-string v9, "AUTH_TOKEN"

    invoke-virtual {v5, v9, v7}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 58
    const-string v9, "AUTH_USERIGGID"

    invoke-virtual {v5, v9, v8}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 59
    const-string v9, "AUTH_GAMEUSERID"

    invoke-virtual {v5, v9, v4}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 60
    const-string v9, "AUTH_GAMEID"

    invoke-virtual {v5, v9, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 61
    invoke-virtual {v5}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v6

    .line 62
    .local v6, "strJson":Ljava/lang/String;
    new-instance v1, Lcom/igg/android/wegamers/auth/DesUtils;

    const-string v9, "IGG_AUTH_KEY"

    invoke-direct {v1, v9}, Lcom/igg/android/wegamers/auth/DesUtils;-><init>(Ljava/lang/String;)V

    .line 63
    .local v1, "des":Lcom/igg/android/wegamers/auth/DesUtils;
    invoke-virtual {v1, v6}, Lcom/igg/android/wegamers/auth/DesUtils;->encrypt(Ljava/lang/String;)Ljava/lang/String;
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1

    move-result-object v0

    .line 69
    .end local v1    # "des":Lcom/igg/android/wegamers/auth/DesUtils;
    .end local v6    # "strJson":Ljava/lang/String;
    :goto_0
    return-object v0

    .line 64
    :catch_0
    move-exception v2

    .line 65
    .local v2, "e":Lorg/json/JSONException;
    invoke-virtual {v2}, Lorg/json/JSONException;->printStackTrace()V

    goto :goto_0

    .line 66
    .end local v2    # "e":Lorg/json/JSONException;
    :catch_1
    move-exception v2

    .line 67
    .local v2, "e":Ljava/lang/Exception;
    invoke-virtual {v2}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method

.method public static responseAuthResult(ILcom/igg/android/wegamers/auth/AuthInfo;)V
    .locals 1
    .param p0, "iRet"    # I
    .param p1, "authInfo"    # Lcom/igg/android/wegamers/auth/AuthInfo;

    .prologue
    .line 25
    sget-object v0, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->mAuthResponse:Lcom/igg/android/wegamers/auth/IAuthResponse;

    if-eqz v0, :cond_0

    .line 26
    sget-object v0, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->mAuthResponse:Lcom/igg/android/wegamers/auth/IAuthResponse;

    invoke-interface {v0, p0, p1}, Lcom/igg/android/wegamers/auth/IAuthResponse;->onComplete(ILcom/igg/android/wegamers/auth/AuthInfo;)V

    .line 28
    :cond_0
    return-void
.end method

.method public static sendAuthInfo(Landroid/content/Context;ILcom/igg/android/wegamers/auth/AuthInfo;)V
    .locals 1
    .param p0, "context"    # Landroid/content/Context;
    .param p1, "iRet"    # I
    .param p2, "authInfo"    # Lcom/igg/android/wegamers/auth/AuthInfo;

    .prologue
    .line 35
    invoke-static {p1, p2}, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->authInfo2Json(ILcom/igg/android/wegamers/auth/AuthInfo;)Ljava/lang/String;

    move-result-object v0

    .line 36
    .local v0, "content":Ljava/lang/String;
    invoke-static {p0, v0}, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->sendBroadcast(Landroid/content/Context;Ljava/lang/String;)V

    .line 37
    return-void
.end method

.method private static sendBroadcast(Landroid/content/Context;Ljava/lang/String;)V
    .locals 4
    .param p0, "context"    # Landroid/content/Context;
    .param p1, "content"    # Ljava/lang/String;

    .prologue
    .line 73
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "wegamersauth://igg.android.wegamers/respones/"

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v1

    .line 74
    .local v1, "uri":Landroid/net/Uri;
    new-instance v0, Landroid/content/Intent;

    const-string v2, "android.intent.action.VIEW"

    invoke-direct {v0, v2, v1}, Landroid/content/Intent;-><init>(Ljava/lang/String;Landroid/net/Uri;)V

    .line 75
    .local v0, "intent":Landroid/content/Intent;
    invoke-virtual {p0, v0}, Landroid/content/Context;->sendBroadcast(Landroid/content/Intent;)V

    .line 76
    return-void
.end method

.method public static setAuthResponse(Lcom/igg/android/wegamers/auth/IAuthResponse;)V
    .locals 0
    .param p0, "authResponse"    # Lcom/igg/android/wegamers/auth/IAuthResponse;

    .prologue
    .line 21
    sput-object p0, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->mAuthResponse:Lcom/igg/android/wegamers/auth/IAuthResponse;

    .line 22
    return-void
.end method
