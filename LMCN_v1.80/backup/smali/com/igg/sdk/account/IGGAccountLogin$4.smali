.class Lcom/igg/sdk/account/IGGAccountLogin$4;
.super Ljava/lang/Object;
.source "IGGAccountLogin.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountLogin;->loginWithFacebook(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountLogin;

.field final synthetic val$expireTime:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/account/LoginListener;

.field final synthetic val$platform_id:Ljava/lang/String;

.field final synthetic val$platform_key:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountLogin;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountLogin;

    .prologue
    .line 361
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountLogin$4;->this$0:Lcom/igg/sdk/account/IGGAccountLogin;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountLogin$4;->val$expireTime:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/sdk/account/IGGAccountLogin$4;->val$platform_key:Ljava/lang/String;

    iput-object p4, p0, Lcom/igg/sdk/account/IGGAccountLogin$4;->val$platform_id:Ljava/lang/String;

    iput-object p5, p0, Lcom/igg/sdk/account/IGGAccountLogin$4;->val$listener:Lcom/igg/sdk/account/LoginListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V
    .locals 8
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
    .line 364
    .local p2, "map":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;"
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 365
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->Facebook:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "IggId"

    .line 367
    invoke-interface {p2, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    const-string v2, "AccessKey"

    .line 368
    invoke-interface {p2, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    const/4 v3, 0x1

    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$4;->val$expireTime:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/sdk/account/IGGAccountLogin$4;->val$platform_key:Ljava/lang/String;

    iget-object v6, p0, Lcom/igg/sdk/account/IGGAccountLogin$4;->val$platform_id:Ljava/lang/String;

    .line 365
    invoke-static/range {v0 .. v6}, Lcom/igg/sdk/account/IGGAccountSession;->quickCreate(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v7

    .line 375
    .local v7, "newSession":Lcom/igg/sdk/account/IGGAccountSession;
    sput-object v7, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 376
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$4;->val$listener:Lcom/igg/sdk/account/LoginListener;

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-interface {v0, p1, v1}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    .line 380
    .end local v7    # "newSession":Lcom/igg/sdk/account/IGGAccountSession;
    :goto_0
    return-void

    .line 378
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$4;->val$listener:Lcom/igg/sdk/account/LoginListener;

    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v1

    invoke-interface {v0, p1, v1}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    goto :goto_0
.end method
