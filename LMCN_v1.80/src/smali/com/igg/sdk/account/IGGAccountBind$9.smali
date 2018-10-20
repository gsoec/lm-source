.class Lcom/igg/sdk/account/IGGAccountBind$9;
.super Ljava/lang/Object;
.source "IGGAccountBind.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountBind;->facebookBind(Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountBind;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountBind;

    .prologue
    .line 710
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountBind$9;->this$0:Lcom/igg/sdk/account/IGGAccountBind;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountBind$9;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V
    .locals 6
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
    const/4 v5, 0x1

    const/4 v4, 0x0

    .line 712
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v2

    if-eqz v2, :cond_3

    .line 713
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v2

    const/16 v3, 0x2727

    if-eq v2, v3, :cond_0

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v2

    const/16 v3, 0x2728

    if-ne v2, v3, :cond_2

    .line 714
    :cond_0
    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountBind$9;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    invoke-interface {v2, v4, v5, v4}, Lcom/igg/sdk/account/IGGAccountBind$BindListener;->onBindFinished(ZZZ)V

    .line 738
    :cond_1
    :goto_0
    return-void

    .line 716
    :cond_2
    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountBind$9;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    invoke-interface {v2, v4, v4, v4}, Lcom/igg/sdk/account/IGGAccountBind$BindListener;->onBindFinished(ZZZ)V

    goto :goto_0

    .line 723
    :cond_3
    const-string v2, "errCode"

    invoke-interface {p2, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 724
    .local v0, "errCode":Ljava/lang/String;
    if-nez v0, :cond_4

    .line 725
    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountBind$9;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    invoke-interface {v2, v4, v4, v4}, Lcom/igg/sdk/account/IGGAccountBind$BindListener;->onBindFinished(ZZZ)V

    goto :goto_0

    .line 729
    :cond_4
    const-string v2, "0"

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_1

    .line 730
    const-string v2, "success"

    invoke-interface {p2, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    .line 731
    .local v1, "success":Ljava/lang/String;
    const-string v2, "1"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_5

    .line 732
    sget-object v2, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v2, v5}, Lcom/igg/sdk/account/IGGAccountSession;->setHasBind(Z)V

    .line 733
    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountBind$9;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    invoke-interface {v2, v5, v4, v4}, Lcom/igg/sdk/account/IGGAccountBind$BindListener;->onBindFinished(ZZZ)V

    goto :goto_0

    .line 735
    :cond_5
    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountBind$9;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    invoke-interface {v2, v4, v4, v4}, Lcom/igg/sdk/account/IGGAccountBind$BindListener;->onBindFinished(ZZZ)V

    goto :goto_0
.end method
