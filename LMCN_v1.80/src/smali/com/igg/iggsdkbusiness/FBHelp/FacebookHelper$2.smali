.class Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;
.super Ljava/lang/Object;
.source "FacebookHelper.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->handleThirdBind(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

.field final synthetic val$email:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;

.field final synthetic val$name:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    .prologue
    .line 439
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->val$listener:Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;

    iput-object p3, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->val$name:Ljava/lang/String;

    iput-object p4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->val$email:Ljava/lang/String;

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
    .local p2, "map":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;"
    const/4 v8, 0x1

    const/4 v7, 0x0

    .line 441
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v4

    if-eqz v4, :cond_0

    .line 442
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->val$listener:Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;

    const-string v5, "isOccurred"

    invoke-interface {v4, v7, v7, v7, v5}, Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;->onBindFinished(ZZZLjava/lang/String;)V

    .line 476
    :goto_0
    return-void

    .line 445
    :cond_0
    const-string v4, "errCode"

    invoke-interface {p2, v4}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    .line 446
    .local v1, "errorCode":Ljava/lang/String;
    const-string v4, "success"

    invoke-interface {p2, v4}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 447
    .local v3, "success":Ljava/lang/String;
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "handleThirdBind errStr = "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "result"

    invoke-interface {p2, v6}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 448
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "handleThirdBind errCode = "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "errCode"

    invoke-interface {p2, v6}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 449
    const-string v4, "1"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1

    .line 452
    :try_start_0
    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v2

    .line 453
    .local v2, "oldExtra":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    sget-object v4, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->BindNameTag:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->val$name:Ljava/lang/String;

    invoke-interface {v2, v4, v5}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 454
    sget-object v4, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->LoginMailTag:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->val$email:Ljava/lang/String;

    invoke-interface {v2, v4, v5}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 455
    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v4, v2}, Lcom/igg/sdk/account/IGGAccountSession;->setExtra(Ljava/util/Map;)V

    .line 459
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "handleThirdBind 1  = "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->val$email:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 460
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "handleThirdBind  1= "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->val$name:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 461
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "handleThirdBind  1= "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    sget-object v6, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v6}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 466
    .end local v2    # "oldExtra":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    :goto_1
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->val$listener:Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;

    invoke-interface {v4, v8, v7, v7, v1}, Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;->onBindFinished(ZZZLjava/lang/String;)V

    goto/16 :goto_0

    .line 463
    :catch_0
    move-exception v0

    .line 464
    .local v0, "e":Ljava/lang/Exception;
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "onLoginOperationFinished Exception  = "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1

    .line 467
    .end local v0    # "e":Ljava/lang/Exception;
    :cond_1
    const-string v4, "errCode"

    invoke-interface {p2, v4}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/String;

    const-string v5, "10023"

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_2

    .line 469
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->val$listener:Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;

    invoke-interface {v4, v7, v8, v7, v1}, Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;->onBindFinished(ZZZLjava/lang/String;)V

    goto/16 :goto_0

    .line 470
    :cond_2
    const-string v4, "errCode"

    invoke-interface {p2, v4}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/String;

    const-string v5, "10024"

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_3

    .line 472
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->val$listener:Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;

    invoke-interface {v4, v7, v8, v7, v1}, Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;->onBindFinished(ZZZLjava/lang/String;)V

    goto/16 :goto_0

    .line 474
    :cond_3
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;->val$listener:Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;

    invoke-interface {v4, v7, v7, v7, v1}, Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;->onBindFinished(ZZZLjava/lang/String;)V

    goto/16 :goto_0
.end method
