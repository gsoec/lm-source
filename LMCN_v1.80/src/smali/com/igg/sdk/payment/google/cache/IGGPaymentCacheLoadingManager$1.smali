.class Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager$1;
.super Ljava/lang/Object;
.source "IGGPaymentCacheLoadingManager.java"

# interfaces
.implements Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->loadCache(ZLcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

.field final synthetic val$listener:Lcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;Lcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

    .prologue
    .line 46
    iput-object p1, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

    iput-object p2, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager$1;->val$listener:Lcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPaymentCardsComposed(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V
    .locals 2
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/error/IGGError;",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 50
    .local p2, "iggGameItems":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 51
    iget-object v0, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

    invoke-static {v0, p2}, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->access$002(Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;Ljava/util/List;)Ljava/util/List;

    .line 52
    iget-object v0, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager$1;->val$listener:Lcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;

    invoke-interface {v0, p2}, Lcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;->onLoadCacheFinished(Ljava/util/List;)V

    .line 56
    :goto_0
    return-void

    .line 54
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager$1;->val$listener:Lcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;

    iget-object v1, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

    invoke-static {v1}, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->access$100(Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;)Ljava/util/ArrayList;

    move-result-object v1

    invoke-interface {v0, v1}, Lcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;->onLoadCacheFinished(Ljava/util/List;)V

    goto :goto_0
.end method
