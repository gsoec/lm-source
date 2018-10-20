.class Lcom/igg/sdk/account/IGGAccountLogin$9;
.super Ljava/lang/Object;
.source "IGGAccountLogin.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountLogin;->loginWithIGGAccount(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountLogin;

.field final synthetic val$expireTime:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountLogin;Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountLogin;

    .prologue
    .line 688
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountLogin$9;->this$0:Lcom/igg/sdk/account/IGGAccountLogin;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountLogin$9;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;

    iput-object p3, p0, Lcom/igg/sdk/account/IGGAccountLogin$9;->val$expireTime:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    .locals 11
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseJSON"    # Lorg/json/JSONObject;
    .param p3, "responseRaw"    # Ljava/lang/String;

    .prologue
    const/4 v1, 0x1

    .line 692
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 693
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$9;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;

    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v1

    const-string v2, "B000"

    const/4 v3, 0x0

    invoke-interface {v0, v1, v2, v3}, Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;->onLoginFinished(Lcom/igg/sdk/account/IGGAccountSession;Ljava/lang/String;Ljava/lang/String;)V

    .line 737
    :goto_0
    return-void

    .line 700
    :cond_0
    :try_start_0
    const-string v0, "login"

    invoke-virtual {p2, v0}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v0

    if-eq v0, v1, :cond_1

    .line 702
    new-instance v7, Lorg/json/JSONObject;

    invoke-direct {v7, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 703
    .local v7, "JSON":Lorg/json/JSONObject;
    const-string v0, "errCode"

    invoke-virtual {v7, v0}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v9

    .line 704
    .local v9, "code":I
    packed-switch v9, :pswitch_data_0

    .line 711
    invoke-static {v9}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v8

    .line 714
    .local v8, "businessCode":Ljava/lang/String;
    :goto_1
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$9;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;

    .line 715
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v1

    const-string v2, ""

    .line 714
    invoke-interface {v0, v1, v8, v2}, Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;->onLoginFinished(Lcom/igg/sdk/account/IGGAccountSession;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 733
    .end local v7    # "JSON":Lorg/json/JSONObject;
    .end local v8    # "businessCode":Ljava/lang/String;
    .end local v9    # "code":I
    :catch_0
    move-exception v10

    .line 734
    .local v10, "e":Lorg/json/JSONException;
    invoke-virtual {v10}, Lorg/json/JSONException;->printStackTrace()V

    .line 735
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$9;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;

    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v1

    const-string v2, "B001"

    invoke-virtual {v10}, Lorg/json/JSONException;->getMessage()Ljava/lang/String;

    move-result-object v3

    invoke-interface {v0, v1, v2, v3}, Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;->onLoginFinished(Lcom/igg/sdk/account/IGGAccountSession;Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 707
    .end local v10    # "e":Lorg/json/JSONException;
    .restart local v7    # "JSON":Lorg/json/JSONObject;
    .restart local v9    # "code":I
    :pswitch_0
    :try_start_1
    const-string v8, "B101"

    .line 708
    .restart local v8    # "businessCode":Ljava/lang/String;
    goto :goto_1

    .line 721
    .end local v7    # "JSON":Lorg/json/JSONObject;
    .end local v8    # "businessCode":Ljava/lang/String;
    .end local v9    # "code":I
    :cond_1
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->IGG:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "iggid"

    .line 723
    invoke-virtual {p2, v1}, Lorg/json/JSONObject;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    const-string v2, "access_key"

    .line 724
    invoke-virtual {p2, v2}, Lorg/json/JSONObject;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    const/4 v3, 0x1

    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$9;->val$expireTime:Ljava/lang/String;

    const-string v5, ""

    const-string v6, ""

    .line 721
    invoke-static/range {v0 .. v6}, Lcom/igg/sdk/account/IGGAccountSession;->quickCreate(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v0

    sput-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 730
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$9;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    const-string v2, "0"

    const-string v3, ""

    invoke-interface {v0, v1, v2, v3}, Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;->onLoginFinished(Lcom/igg/sdk/account/IGGAccountSession;Ljava/lang/String;Ljava/lang/String;)V

    .line 731
    invoke-static {}, Lcom/igg/sdk/IGGAppProfile;->sharedInstance()Lcom/igg/sdk/IGGAppProfile;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGAppProfile;->updateLastLoginTime()V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0

    .line 704
    nop

    :pswitch_data_0
    .packed-switch 0x186a5
        :pswitch_0
        :pswitch_0
    .end packed-switch
.end method
