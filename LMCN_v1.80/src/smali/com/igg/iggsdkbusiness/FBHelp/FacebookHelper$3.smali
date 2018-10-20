.class Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;
.super Ljava/lang/Object;
.source "FacebookHelper.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->handleSwitchFacebook(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

.field final synthetic val$email:Ljava/lang/String;

.field final synthetic val$expireTime:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

.field final synthetic val$name:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    .prologue
    .line 500
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;->val$email:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;->val$name:Ljava/lang/String;

    iput-object p4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;->val$expireTime:Ljava/lang/String;

    iput-object p5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V
    .locals 10
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
    const/4 v3, 0x0

    .line 504
    const-string v0, "GetToken"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "handleSwitchFacebook2-1 error = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 505
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 507
    const-string v0, "GetToken"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "handleSwitchFacebook3 Type ="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getType()Lcom/igg/sdk/error/IGGError$Type;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 508
    new-instance v9, Ljava/util/HashMap;

    invoke-direct {v9}, Ljava/util/HashMap;-><init>()V

    .line 509
    .local v9, "sessionExtra":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    sget-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->LoginMailTag:Ljava/lang/String;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;->val$email:Ljava/lang/String;

    invoke-virtual {v9, v0, v1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 510
    sget-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->BindNameTag:Ljava/lang/String;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;->val$name:Ljava/lang/String;

    invoke-virtual {v9, v0, v1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 513
    :try_start_0
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->Facebook:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "IggId"

    .line 515
    invoke-interface {p2, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    const-string v2, "AccessKey"

    .line 516
    invoke-interface {p2, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    const/4 v3, 0x0

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;->val$expireTime:Ljava/lang/String;

    const-string v5, ""

    const-string v6, ""

    .line 513
    invoke-static/range {v0 .. v6}, Lcom/igg/sdk/account/IGGAccountSession;->quickCreate(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v8

    .line 522
    .local v8, "newSession":Lcom/igg/sdk/account/IGGAccountSession;
    const-string v0, "GetToken"

    const-string v1, "handleSwitchFacebook5"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 523
    invoke-virtual {v8, v9}, Lcom/igg/sdk/account/IGGAccountSession;->setExtra(Ljava/util/Map;)V

    .line 525
    sput-object v8, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 527
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v1

    sget-object v2, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    const/4 v3, 0x0

    invoke-interface {v0, v1, v2, v3}, Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;->onSwitchLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;Z)V

    .line 528
    invoke-static {}, Lcom/igg/sdk/IGGAppProfile;->sharedInstance()Lcom/igg/sdk/IGGAppProfile;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGAppProfile;->updateLastLoginTime()V

    .line 530
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "handleSwitchFacebook  getExtra = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    sget-object v2, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 540
    .end local v8    # "newSession":Lcom/igg/sdk/account/IGGAccountSession;
    .end local v9    # "sessionExtra":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    :goto_0
    return-void

    .line 532
    .restart local v9    # "sessionExtra":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    :catch_0
    move-exception v7

    .line 534
    .local v7, "ex":Ljava/lang/Exception;
    const-string v0, "GetToken"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "handleSwitchFacebook5 Exception = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v7}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 539
    .end local v7    # "ex":Ljava/lang/Exception;
    .end local v9    # "sessionExtra":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

    const/4 v1, 0x0

    invoke-interface {v0, p1, v1, v3}, Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;->onSwitchLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;Z)V

    goto :goto_0
.end method
