.class Lcom/igg/sdk/account/IGGAccountLogin$5;
.super Ljava/lang/Object;
.source "IGGAccountLogin.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountLogin;->loginWithWeChat(Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountLogin;

.field final synthetic val$expireTime:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/account/LoginListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountLogin;Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountLogin;

    .prologue
    .line 402
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountLogin$5;->this$0:Lcom/igg/sdk/account/IGGAccountLogin;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountLogin$5;->val$expireTime:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/sdk/account/IGGAccountLogin$5;->val$listener:Lcom/igg/sdk/account/LoginListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V
    .locals 9
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/error/IGGError;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 405
    .local p2, "map":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;"
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 406
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->WECHAT:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "IggId"

    .line 408
    invoke-interface {p2, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    const-string v2, "AccessKey"

    .line 409
    invoke-interface {p2, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    const/4 v3, 0x1

    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$5;->val$expireTime:Ljava/lang/String;

    const/4 v5, 0x0

    const-string v6, "platformUid"

    .line 413
    invoke-interface {p2, v6}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/lang/String;

    .line 406
    invoke-static/range {v0 .. v6}, Lcom/igg/sdk/account/IGGAccountSession;->quickCreate(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v8

    .line 416
    .local v8, "newSession":Lcom/igg/sdk/account/IGGAccountSession;
    new-instance v7, Ljava/util/HashMap;

    invoke-direct {v7}, Ljava/util/HashMap;-><init>()V

    .line 417
    .local v7, "data":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "wechat_info"

    const-string v0, "wechat_info"

    invoke-interface {p2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-virtual {v7, v1, v0}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 418
    invoke-virtual {v8, v7}, Lcom/igg/sdk/account/IGGAccountSession;->setExtra(Ljava/util/Map;)V

    .line 420
    sput-object v8, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 421
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$5;->val$listener:Lcom/igg/sdk/account/LoginListener;

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-interface {v0, p1, v1}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    .line 425
    .end local v7    # "data":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v8    # "newSession":Lcom/igg/sdk/account/IGGAccountSession;
    :goto_0
    return-void

    .line 423
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$5;->val$listener:Lcom/igg/sdk/account/LoginListener;

    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v1

    invoke-interface {v0, p1, v1}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    goto :goto_0
.end method
