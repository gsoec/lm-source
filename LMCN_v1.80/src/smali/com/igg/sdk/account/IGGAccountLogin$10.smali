.class Lcom/igg/sdk/account/IGGAccountLogin$10;
.super Ljava/lang/Object;
.source "IGGAccountLogin.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountLogin;->registerIGGAccount(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZLcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountLogin;

.field final synthetic val$expireTime:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;

.field final synthetic val$loginAtSameTime:Z


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountLogin;Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;ZLjava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountLogin;

    .prologue
    .line 774
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountLogin$10;->this$0:Lcom/igg/sdk/account/IGGAccountLogin;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountLogin$10;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;

    iput-boolean p3, p0, Lcom/igg/sdk/account/IGGAccountLogin$10;->val$loginAtSameTime:Z

    iput-object p4, p0, Lcom/igg/sdk/account/IGGAccountLogin$10;->val$expireTime:Ljava/lang/String;

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
    const/4 v2, 0x0

    const/4 v1, 0x1

    .line 778
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 779
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$10;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;

    const-string v1, "0"

    invoke-interface {v0, v1, v2, v2}, Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;->onRegisterFinished(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 838
    :goto_0
    return-void

    .line 786
    :cond_0
    :try_start_0
    const-string v0, "login"

    invoke-virtual {p2, v0}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v0

    if-eq v0, v1, :cond_1

    .line 788
    new-instance v7, Lorg/json/JSONObject;

    invoke-direct {v7, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 789
    .local v7, "JSON":Lorg/json/JSONObject;
    const-string v0, "errCode"

    invoke-virtual {v7, v0}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v9

    .line 790
    .local v9, "code":I
    packed-switch v9, :pswitch_data_0

    .line 812
    :pswitch_0
    invoke-static {v9}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v8

    .line 815
    .local v8, "businessCode":Ljava/lang/String;
    :goto_1
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$10;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;

    const-string v1, "0"

    const-string v2, ""

    invoke-interface {v0, v1, v8, v2}, Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;->onRegisterFinished(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 834
    .end local v7    # "JSON":Lorg/json/JSONObject;
    .end local v8    # "businessCode":Ljava/lang/String;
    .end local v9    # "code":I
    :catch_0
    move-exception v10

    .line 835
    .local v10, "e":Lorg/json/JSONException;
    invoke-virtual {v10}, Lorg/json/JSONException;->printStackTrace()V

    .line 836
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$10;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;

    const-string v1, "0"

    const-string v2, "B001"

    invoke-virtual {v10}, Lorg/json/JSONException;->getMessage()Ljava/lang/String;

    move-result-object v3

    invoke-interface {v0, v1, v2, v3}, Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;->onRegisterFinished(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 793
    .end local v10    # "e":Lorg/json/JSONException;
    .restart local v7    # "JSON":Lorg/json/JSONObject;
    .restart local v9    # "code":I
    :pswitch_1
    :try_start_1
    const-string v8, "B101"

    .line 794
    .restart local v8    # "businessCode":Ljava/lang/String;
    goto :goto_1

    .line 797
    .end local v8    # "businessCode":Ljava/lang/String;
    :pswitch_2
    const-string v8, "B102"

    .line 798
    .restart local v8    # "businessCode":Ljava/lang/String;
    goto :goto_1

    .line 802
    .end local v8    # "businessCode":Ljava/lang/String;
    :pswitch_3
    const-string v8, "B103"

    .line 803
    .restart local v8    # "businessCode":Ljava/lang/String;
    goto :goto_1

    .line 808
    .end local v8    # "businessCode":Ljava/lang/String;
    :pswitch_4
    const-string v8, "B104"

    .line 809
    .restart local v8    # "businessCode":Ljava/lang/String;
    goto :goto_1

    .line 821
    .end local v7    # "JSON":Lorg/json/JSONObject;
    .end local v8    # "businessCode":Ljava/lang/String;
    .end local v9    # "code":I
    :cond_1
    iget-boolean v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$10;->val$loginAtSameTime:Z

    if-eqz v0, :cond_2

    .line 822
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->IGG:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "iggid"

    .line 824
    invoke-virtual {p2, v1}, Lorg/json/JSONObject;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    const-string v2, "access_key"

    .line 825
    invoke-virtual {p2, v2}, Lorg/json/JSONObject;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    const/4 v3, 0x1

    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$10;->val$expireTime:Ljava/lang/String;

    const-string v5, ""

    const-string v6, ""

    .line 822
    invoke-static/range {v0 .. v6}, Lcom/igg/sdk/account/IGGAccountSession;->quickCreate(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v0

    sput-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 833
    :cond_2
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$10;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;

    const-string v1, "iggid"

    invoke-virtual {p2, v1}, Lorg/json/JSONObject;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    const-string v2, "0"

    const-string v3, ""

    invoke-interface {v0, v1, v2, v3}, Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;->onRegisterFinished(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0

    .line 790
    nop

    :pswitch_data_0
    .packed-switch 0x186a2
        :pswitch_1
        :pswitch_1
        :pswitch_0
        :pswitch_2
        :pswitch_0
        :pswitch_0
        :pswitch_3
        :pswitch_3
        :pswitch_0
        :pswitch_4
        :pswitch_4
        :pswitch_4
    .end packed-switch
.end method
