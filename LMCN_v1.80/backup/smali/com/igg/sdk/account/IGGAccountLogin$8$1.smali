.class Lcom/igg/sdk/account/IGGAccountLogin$8$1;
.super Ljava/lang/Object;
.source "IGGAccountLogin.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountLogin$8;->onPostExecute(Ljava/lang/Object;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/sdk/account/IGGAccountLogin$8;

.field final synthetic val$expireTime:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountLogin$8;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/sdk/account/IGGAccountLogin$8;

    .prologue
    .line 623
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountLogin$8$1;->this$1:Lcom/igg/sdk/account/IGGAccountLogin$8;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountLogin$8$1;->val$expireTime:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V
    .locals 11
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
    .local p2, "map":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;"
    const/4 v10, 0x0

    .line 626
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 627
    const-string v0, "login"

    invoke-interface {p2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Ljava/lang/String;

    .line 630
    .local v7, "loginFlag":Ljava/lang/String;
    const-string v0, "1"

    invoke-virtual {v7, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 631
    new-instance v9, Ljava/util/HashMap;

    invoke-direct {v9}, Ljava/util/HashMap;-><init>()V

    .line 632
    .local v9, "sessionExtra":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v0, "email"

    iget-object v1, p0, Lcom/igg/sdk/account/IGGAccountLogin$8$1;->this$1:Lcom/igg/sdk/account/IGGAccountLogin$8;

    iget-object v1, v1, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$email:Ljava/lang/String;

    invoke-virtual {v9, v0, v1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 634
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "IggId"

    .line 636
    invoke-interface {p2, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    const-string v2, "AccessKey"

    .line 637
    invoke-interface {p2, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    const/4 v3, 0x1

    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$8$1;->val$expireTime:Ljava/lang/String;

    const-string v5, ""

    const-string v6, ""

    .line 634
    invoke-static/range {v0 .. v6}, Lcom/igg/sdk/account/IGGAccountSession;->quickCreate(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v8

    .line 644
    .local v8, "newSession":Lcom/igg/sdk/account/IGGAccountSession;
    invoke-virtual {v8, v9}, Lcom/igg/sdk/account/IGGAccountSession;->setExtra(Ljava/util/Map;)V

    .line 646
    sput-object v8, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 648
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$8$1;->this$1:Lcom/igg/sdk/account/IGGAccountLogin$8;

    iget-object v0, v0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-interface {v0, p1, v1, v10}, Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;->onSwitchLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;Z)V

    .line 649
    invoke-static {}, Lcom/igg/sdk/IGGAppProfile;->sharedInstance()Lcom/igg/sdk/IGGAppProfile;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGAppProfile;->updateLastLoginTime()V

    .line 656
    .end local v7    # "loginFlag":Ljava/lang/String;
    .end local v8    # "newSession":Lcom/igg/sdk/account/IGGAccountSession;
    .end local v9    # "sessionExtra":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    :goto_0
    return-void

    .line 651
    .restart local v7    # "loginFlag":Ljava/lang/String;
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$8$1;->this$1:Lcom/igg/sdk/account/IGGAccountLogin$8;

    iget-object v0, v0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v1

    invoke-interface {v0, p1, v1, v10}, Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;->onSwitchLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;Z)V

    goto :goto_0

    .line 654
    .end local v7    # "loginFlag":Ljava/lang/String;
    :cond_1
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$8$1;->this$1:Lcom/igg/sdk/account/IGGAccountLogin$8;

    iget-object v0, v0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v1

    invoke-interface {v0, p1, v1, v10}, Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;->onSwitchLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;Z)V

    goto :goto_0
.end method
