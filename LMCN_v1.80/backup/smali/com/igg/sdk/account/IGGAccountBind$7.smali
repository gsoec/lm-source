.class Lcom/igg/sdk/account/IGGAccountBind$7;
.super Ljava/lang/Object;
.source "IGGAccountBind.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountBind;->bindToWeChat(Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountBind;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountBind;

    .prologue
    .line 585
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountBind$7;->this$0:Lcom/igg/sdk/account/IGGAccountBind;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountBind$7;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;

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
    const/4 v9, 0x1

    const/4 v8, 0x0

    .line 587
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v5

    if-eqz v5, :cond_1

    .line 589
    const-string v0, ""

    .line 590
    .local v0, "code":Ljava/lang/String;
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v3

    .line 591
    .local v3, "errorCode":I
    const-string v5, "IGGAccountBind"

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "errCode\uff1a"

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    const-string v7, "errCode"

    invoke-interface {p2, v7}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v7

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v5, v6}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 592
    sparse-switch v3, :sswitch_data_0

    .line 612
    const-string v1, " "

    .line 613
    .local v1, "desc":Ljava/lang/String;
    const-string v0, "500"

    .line 616
    :goto_0
    iget-object v5, p0, Lcom/igg/sdk/account/IGGAccountBind$7;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;

    invoke-interface {v5, v8, v0, v1}, Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    .line 635
    .end local v0    # "code":Ljava/lang/String;
    .end local v1    # "desc":Ljava/lang/String;
    .end local v3    # "errorCode":I
    :cond_0
    :goto_1
    return-void

    .line 594
    .restart local v0    # "code":Ljava/lang/String;
    .restart local v3    # "errorCode":I
    :sswitch_0
    const-string v1, "invalid wechat auth code, maybe it\'s expired"

    .line 595
    .restart local v1    # "desc":Ljava/lang/String;
    const-string v0, "1"

    .line 596
    goto :goto_0

    .line 599
    .end local v1    # "desc":Ljava/lang/String;
    :sswitch_1
    const-string v1, "the wechat account had been bound to anoter IGG Id"

    .line 600
    .restart local v1    # "desc":Ljava/lang/String;
    const-string v0, "2"

    .line 601
    goto :goto_0

    .line 604
    .end local v1    # "desc":Ljava/lang/String;
    :sswitch_2
    const-string v1, "this IGG Id had been bound to third account"

    .line 605
    .restart local v1    # "desc":Ljava/lang/String;
    const-string v0, "3"

    .line 606
    goto :goto_0

    .line 609
    .end local v1    # "desc":Ljava/lang/String;
    :sswitch_3
    const-string v1, "an exception happened, check underlying error for detail"

    .line 610
    .restart local v1    # "desc":Ljava/lang/String;
    goto :goto_0

    .line 620
    .end local v0    # "code":Ljava/lang/String;
    .end local v1    # "desc":Ljava/lang/String;
    .end local v3    # "errorCode":I
    :cond_1
    const-string v5, "errCode"

    invoke-interface {p2, v5}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 621
    .local v2, "errCode":Ljava/lang/String;
    if-nez v2, :cond_2

    .line 622
    iget-object v5, p0, Lcom/igg/sdk/account/IGGAccountBind$7;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;

    const-string v6, ""

    const-string v7, ""

    invoke-interface {v5, v8, v6, v7}, Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto :goto_1

    .line 626
    :cond_2
    const-string v5, "0"

    invoke-virtual {v2, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-eqz v5, :cond_0

    .line 627
    const-string v5, "success"

    invoke-interface {p2, v5}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/String;

    .line 628
    .local v4, "success":Ljava/lang/String;
    const-string v5, "1"

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-eqz v5, :cond_3

    .line 629
    sget-object v5, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v5, v9}, Lcom/igg/sdk/account/IGGAccountSession;->setHasBind(Z)V

    .line 630
    iget-object v5, p0, Lcom/igg/sdk/account/IGGAccountBind$7;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;

    const-string v6, "0"

    const-string v7, "bind success"

    invoke-interface {v5, v9, v6, v7}, Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto :goto_1

    .line 632
    :cond_3
    iget-object v5, p0, Lcom/igg/sdk/account/IGGAccountBind$7;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;

    const-string v6, ""

    const-string v7, ""

    invoke-interface {v5, v8, v6, v7}, Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto :goto_1

    .line 592
    :sswitch_data_0
    .sparse-switch
        0x192 -> :sswitch_0
        0x1f4 -> :sswitch_3
        0x30e32 -> :sswitch_1
        0x30e33 -> :sswitch_2
    .end sparse-switch
.end method
