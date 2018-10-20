.class Lcom/igg/sdk/account/IGGAccountBind$8;
.super Ljava/lang/Object;
.source "IGGAccountBind.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountBind;->bindToAmazonCount(Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountBind;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountBind;

    .prologue
    .line 651
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountBind$8;->this$0:Lcom/igg/sdk/account/IGGAccountBind;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountBind$8;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;

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

    .line 653
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v5

    if-eqz v5, :cond_0

    .line 656
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v3

    .line 657
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

    .line 658
    sparse-switch v3, :sswitch_data_0

    .line 674
    const-string v1, ""

    .line 675
    .local v1, "desc":Ljava/lang/String;
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, ""

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 678
    .local v0, "code":Ljava/lang/String;
    :goto_0
    iget-object v5, p0, Lcom/igg/sdk/account/IGGAccountBind$8;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;

    invoke-interface {v5, v8, v0, v1}, Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    .line 694
    .end local v0    # "code":Ljava/lang/String;
    .end local v1    # "desc":Ljava/lang/String;
    .end local v3    # "errorCode":I
    :goto_1
    return-void

    .line 660
    .restart local v3    # "errorCode":I
    :sswitch_0
    const-string v1, "invalid amazon auth code, maybe it\'s expired"

    .line 661
    .restart local v1    # "desc":Ljava/lang/String;
    const-string v0, "1"

    .line 662
    .restart local v0    # "code":Ljava/lang/String;
    goto :goto_0

    .line 665
    .end local v0    # "code":Ljava/lang/String;
    .end local v1    # "desc":Ljava/lang/String;
    :sswitch_1
    const-string v1, "the amazon account had been bound to anoter IGG Id"

    .line 666
    .restart local v1    # "desc":Ljava/lang/String;
    const-string v0, "2"

    .line 667
    .restart local v0    # "code":Ljava/lang/String;
    goto :goto_0

    .line 670
    .end local v0    # "code":Ljava/lang/String;
    .end local v1    # "desc":Ljava/lang/String;
    :sswitch_2
    const-string v1, "an exception happened, check underlying error for detail"

    .line 671
    .restart local v1    # "desc":Ljava/lang/String;
    const-string v0, "3"

    .line 672
    .restart local v0    # "code":Ljava/lang/String;
    goto :goto_0

    .line 682
    .end local v0    # "code":Ljava/lang/String;
    .end local v1    # "desc":Ljava/lang/String;
    .end local v3    # "errorCode":I
    :cond_0
    const-string v5, "errCode"

    invoke-interface {p2, v5}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 683
    .local v2, "errCode":Ljava/lang/String;
    if-eqz v2, :cond_2

    const-string v5, "0"

    invoke-virtual {v2, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-eqz v5, :cond_2

    .line 684
    const-string v5, "success"

    invoke-interface {p2, v5}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/String;

    .line 685
    .local v4, "success":Ljava/lang/String;
    const-string v5, "1"

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-eqz v5, :cond_1

    .line 686
    sget-object v5, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v5, v9}, Lcom/igg/sdk/account/IGGAccountSession;->setHasBind(Z)V

    .line 687
    iget-object v5, p0, Lcom/igg/sdk/account/IGGAccountBind$8;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;

    const-string v6, "0"

    const-string v7, "bind success"

    invoke-interface {v5, v9, v6, v7}, Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto :goto_1

    .line 689
    :cond_1
    iget-object v5, p0, Lcom/igg/sdk/account/IGGAccountBind$8;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;

    const-string v6, ""

    const-string v7, ""

    invoke-interface {v5, v8, v6, v7}, Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto :goto_1

    .line 692
    .end local v4    # "success":Ljava/lang/String;
    :cond_2
    iget-object v5, p0, Lcom/igg/sdk/account/IGGAccountBind$8;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;

    const-string v6, ""

    const-string v7, ""

    invoke-interface {v5, v8, v6, v7}, Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto :goto_1

    .line 658
    :sswitch_data_0
    .sparse-switch
        0x192 -> :sswitch_0
        0x1f4 -> :sswitch_2
        0x30e32 -> :sswitch_1
    .end sparse-switch
.end method
