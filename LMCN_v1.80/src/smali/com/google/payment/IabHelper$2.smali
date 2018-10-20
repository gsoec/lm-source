.class Lcom/google/payment/IabHelper$2;
.super Ljava/lang/Object;
.source "IabHelper.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/google/payment/IabHelper;->queryInventoryAsync(ZLjava/util/List;Ljava/util/List;Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/google/payment/IabHelper;

.field final synthetic val$handler:Landroid/os/Handler;

.field final synthetic val$listener:Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;

.field final synthetic val$moreItemSkus:Ljava/util/List;

.field final synthetic val$moreSubsSkus:Ljava/util/List;

.field final synthetic val$querySkuDetails:Z


# direct methods
.method constructor <init>(Lcom/google/payment/IabHelper;ZLjava/util/List;Ljava/util/List;Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;Landroid/os/Handler;)V
    .locals 0
    .param p1, "this$0"    # Lcom/google/payment/IabHelper;

    .prologue
    .line 781
    iput-object p1, p0, Lcom/google/payment/IabHelper$2;->this$0:Lcom/google/payment/IabHelper;

    iput-boolean p2, p0, Lcom/google/payment/IabHelper$2;->val$querySkuDetails:Z

    iput-object p3, p0, Lcom/google/payment/IabHelper$2;->val$moreItemSkus:Ljava/util/List;

    iput-object p4, p0, Lcom/google/payment/IabHelper$2;->val$moreSubsSkus:Ljava/util/List;

    iput-object p5, p0, Lcom/google/payment/IabHelper$2;->val$listener:Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;

    iput-object p6, p0, Lcom/google/payment/IabHelper$2;->val$handler:Landroid/os/Handler;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 9

    .prologue
    .line 783
    new-instance v3, Lcom/google/payment/IabResult;

    const/4 v5, 0x0

    const-string v6, "Inventory refresh successful."

    invoke-direct {v3, v5, v6}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 784
    .local v3, "result":Lcom/google/payment/IabResult;
    const/4 v1, 0x0

    .line 786
    .local v1, "inv":Lcom/google/payment/Inventory;
    :try_start_0
    iget-object v5, p0, Lcom/google/payment/IabHelper$2;->this$0:Lcom/google/payment/IabHelper;

    iget-boolean v6, p0, Lcom/google/payment/IabHelper$2;->val$querySkuDetails:Z

    iget-object v7, p0, Lcom/google/payment/IabHelper$2;->val$moreItemSkus:Ljava/util/List;

    iget-object v8, p0, Lcom/google/payment/IabHelper$2;->val$moreSubsSkus:Ljava/util/List;

    invoke-virtual {v5, v6, v7, v8}, Lcom/google/payment/IabHelper;->queryInventory(ZLjava/util/List;Ljava/util/List;)Lcom/google/payment/Inventory;
    :try_end_0
    .catch Lcom/google/payment/IabException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v1

    .line 792
    :goto_0
    iget-object v5, p0, Lcom/google/payment/IabHelper$2;->this$0:Lcom/google/payment/IabHelper;

    invoke-virtual {v5}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 794
    move-object v4, v3

    .line 795
    .local v4, "result_f":Lcom/google/payment/IabResult;
    move-object v2, v1

    .line 796
    .local v2, "inv_f":Lcom/google/payment/Inventory;
    iget-object v5, p0, Lcom/google/payment/IabHelper$2;->this$0:Lcom/google/payment/IabHelper;

    iget-boolean v5, v5, Lcom/google/payment/IabHelper;->mDisposed:Z

    if-nez v5, :cond_0

    iget-object v5, p0, Lcom/google/payment/IabHelper$2;->val$listener:Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;

    if-eqz v5, :cond_0

    .line 797
    iget-object v5, p0, Lcom/google/payment/IabHelper$2;->val$handler:Landroid/os/Handler;

    new-instance v6, Lcom/google/payment/IabHelper$2$1;

    invoke-direct {v6, p0, v4, v2}, Lcom/google/payment/IabHelper$2$1;-><init>(Lcom/google/payment/IabHelper$2;Lcom/google/payment/IabResult;Lcom/google/payment/Inventory;)V

    invoke-virtual {v5, v6}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 803
    :cond_0
    return-void

    .line 788
    .end local v2    # "inv_f":Lcom/google/payment/Inventory;
    .end local v4    # "result_f":Lcom/google/payment/IabResult;
    :catch_0
    move-exception v0

    .line 789
    .local v0, "ex":Lcom/google/payment/IabException;
    invoke-virtual {v0}, Lcom/google/payment/IabException;->getResult()Lcom/google/payment/IabResult;

    move-result-object v3

    goto :goto_0
.end method
