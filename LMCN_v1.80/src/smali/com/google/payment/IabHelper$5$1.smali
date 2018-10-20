.class Lcom/google/payment/IabHelper$5$1;
.super Ljava/lang/Object;
.source "IabHelper.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/google/payment/IabHelper$5;->run()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/google/payment/IabHelper$5;

.field final synthetic val$results:Ljava/util/List;


# direct methods
.method constructor <init>(Lcom/google/payment/IabHelper$5;Ljava/util/List;)V
    .locals 0
    .param p1, "this$1"    # Lcom/google/payment/IabHelper$5;

    .prologue
    .line 1329
    iput-object p1, p0, Lcom/google/payment/IabHelper$5$1;->this$1:Lcom/google/payment/IabHelper$5;

    iput-object p2, p0, Lcom/google/payment/IabHelper$5$1;->val$results:Ljava/util/List;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 4

    .prologue
    const/4 v3, 0x0

    .line 1331
    iget-object v0, p0, Lcom/google/payment/IabHelper$5$1;->this$1:Lcom/google/payment/IabHelper$5;

    iget-object v2, v0, Lcom/google/payment/IabHelper$5;->val$singleListener:Lcom/google/payment/IabHelper$OnConsumeFinishedListener;

    iget-object v0, p0, Lcom/google/payment/IabHelper$5$1;->this$1:Lcom/google/payment/IabHelper$5;

    iget-object v0, v0, Lcom/google/payment/IabHelper$5;->val$purchases:Ljava/util/List;

    invoke-interface {v0, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/payment/Purchase;

    iget-object v1, p0, Lcom/google/payment/IabHelper$5$1;->val$results:Ljava/util/List;

    invoke-interface {v1, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/google/payment/IabResult;

    invoke-interface {v2, v0, v1}, Lcom/google/payment/IabHelper$OnConsumeFinishedListener;->onConsumeFinished(Lcom/google/payment/Purchase;Lcom/google/payment/IabResult;)V

    .line 1332
    return-void
.end method
