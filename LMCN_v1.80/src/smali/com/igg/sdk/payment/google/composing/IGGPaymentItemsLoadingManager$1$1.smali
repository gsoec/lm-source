.class Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;
.super Ljava/lang/Object;
.source "IGGPaymentItemsLoadingManager.java"

# interfaces
.implements Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->run()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;


# direct methods
.method constructor <init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    .prologue
    .line 81
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;->this$1:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPaymentCardsLoaded(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;)V
    .locals 3
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "result"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    .prologue
    .line 84
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-eqz v0, :cond_2

    .line 85
    const-string v0, "onPaymentCardsLoaded"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "error.isOccurred:"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;->this$1:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    iget-object v2, v2, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$200(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)I

    move-result v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 86
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;->this$1:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    iget-object v0, v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$200(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)I

    move-result v0

    if-nez v0, :cond_0

    .line 87
    invoke-static {}, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->sharedInstance()Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;->this$1:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    iget-object v1, v1, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$300(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Z

    move-result v1

    new-instance v2, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1$1;

    invoke-direct {v2, p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1$1;-><init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;)V

    invoke-virtual {v0, v1, v2}, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->loadCache(ZLcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;)V

    .line 97
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;->this$1:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    iget-object v0, v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$500(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 98
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;->this$1:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    iget-object v0, v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    const/4 v1, 0x0

    invoke-static {v0, p1, v1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$600(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    .line 109
    :cond_1
    :goto_0
    return-void

    .line 104
    :cond_2
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;->this$1:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    iget-object v0, v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0, p2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$002(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;)Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    .line 106
    invoke-static {}, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->sharedInstance()Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;->this$1:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    iget-object v1, v1, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$000(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->getIGGGameItems()Ljava/util/ArrayList;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->saveCache(Ljava/util/ArrayList;)V

    .line 108
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;->this$1:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    iget-object v0, v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$100(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)V

    goto :goto_0
.end method
