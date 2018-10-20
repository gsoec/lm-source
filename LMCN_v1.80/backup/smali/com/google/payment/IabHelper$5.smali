.class Lcom/google/payment/IabHelper$5;
.super Ljava/lang/Object;
.source "IabHelper.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/google/payment/IabHelper;->consumeAsyncInternal(Ljava/util/List;Lcom/google/payment/IabHelper$OnConsumeFinishedListener;Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/google/payment/IabHelper;

.field final synthetic val$handler:Landroid/os/Handler;

.field final synthetic val$multiListener:Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;

.field final synthetic val$purchases:Ljava/util/List;

.field final synthetic val$singleListener:Lcom/google/payment/IabHelper$OnConsumeFinishedListener;


# direct methods
.method constructor <init>(Lcom/google/payment/IabHelper;Ljava/util/List;Lcom/google/payment/IabHelper$OnConsumeFinishedListener;Landroid/os/Handler;Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/google/payment/IabHelper;

    .prologue
    .line 1314
    iput-object p1, p0, Lcom/google/payment/IabHelper$5;->this$0:Lcom/google/payment/IabHelper;

    iput-object p2, p0, Lcom/google/payment/IabHelper$5;->val$purchases:Ljava/util/List;

    iput-object p3, p0, Lcom/google/payment/IabHelper$5;->val$singleListener:Lcom/google/payment/IabHelper$OnConsumeFinishedListener;

    iput-object p4, p0, Lcom/google/payment/IabHelper$5;->val$handler:Landroid/os/Handler;

    iput-object p5, p0, Lcom/google/payment/IabHelper$5;->val$multiListener:Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 8

    .prologue
    .line 1316
    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    .line 1317
    .local v2, "results":Ljava/util/List;, "Ljava/util/List<Lcom/google/payment/IabResult;>;"
    iget-object v3, p0, Lcom/google/payment/IabHelper$5;->val$purchases:Ljava/util/List;

    invoke-interface {v3}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v3

    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v4

    if-eqz v4, :cond_0

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/google/payment/Purchase;

    .line 1319
    .local v1, "purchase":Lcom/google/payment/Purchase;
    :try_start_0
    iget-object v4, p0, Lcom/google/payment/IabHelper$5;->this$0:Lcom/google/payment/IabHelper;

    invoke-virtual {v4, v1}, Lcom/google/payment/IabHelper;->consume(Lcom/google/payment/Purchase;)V

    .line 1320
    new-instance v4, Lcom/google/payment/IabResult;

    const/4 v5, 0x0

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "Successful consume of sku "

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v1}, Lcom/google/payment/Purchase;->getSku()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-direct {v4, v5, v6}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    invoke-interface {v2, v4}, Ljava/util/List;->add(Ljava/lang/Object;)Z
    :try_end_0
    .catch Lcom/google/payment/IabException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 1322
    :catch_0
    move-exception v0

    .line 1323
    .local v0, "ex":Lcom/google/payment/IabException;
    invoke-virtual {v0}, Lcom/google/payment/IabException;->getResult()Lcom/google/payment/IabResult;

    move-result-object v4

    invoke-interface {v2, v4}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    .line 1327
    .end local v0    # "ex":Lcom/google/payment/IabException;
    .end local v1    # "purchase":Lcom/google/payment/Purchase;
    :cond_0
    iget-object v3, p0, Lcom/google/payment/IabHelper$5;->this$0:Lcom/google/payment/IabHelper;

    invoke-virtual {v3}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 1328
    iget-object v3, p0, Lcom/google/payment/IabHelper$5;->this$0:Lcom/google/payment/IabHelper;

    iget-boolean v3, v3, Lcom/google/payment/IabHelper;->mDisposed:Z

    if-nez v3, :cond_1

    iget-object v3, p0, Lcom/google/payment/IabHelper$5;->val$singleListener:Lcom/google/payment/IabHelper$OnConsumeFinishedListener;

    if-eqz v3, :cond_1

    .line 1329
    iget-object v3, p0, Lcom/google/payment/IabHelper$5;->val$handler:Landroid/os/Handler;

    new-instance v4, Lcom/google/payment/IabHelper$5$1;

    invoke-direct {v4, p0, v2}, Lcom/google/payment/IabHelper$5$1;-><init>(Lcom/google/payment/IabHelper$5;Ljava/util/List;)V

    invoke-virtual {v3, v4}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 1335
    :cond_1
    iget-object v3, p0, Lcom/google/payment/IabHelper$5;->this$0:Lcom/google/payment/IabHelper;

    iget-boolean v3, v3, Lcom/google/payment/IabHelper;->mDisposed:Z

    if-nez v3, :cond_2

    iget-object v3, p0, Lcom/google/payment/IabHelper$5;->val$multiListener:Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;

    if-eqz v3, :cond_2

    .line 1336
    iget-object v3, p0, Lcom/google/payment/IabHelper$5;->val$handler:Landroid/os/Handler;

    new-instance v4, Lcom/google/payment/IabHelper$5$2;

    invoke-direct {v4, p0, v2}, Lcom/google/payment/IabHelper$5$2;-><init>(Lcom/google/payment/IabHelper$5;Ljava/util/List;)V

    invoke-virtual {v3, v4}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 1342
    :cond_2
    return-void
.end method
