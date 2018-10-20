.class Lcom/google/payment/IabHelper$2$1;
.super Ljava/lang/Object;
.source "IabHelper.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/google/payment/IabHelper$2;->run()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/google/payment/IabHelper$2;

.field final synthetic val$inv_f:Lcom/google/payment/Inventory;

.field final synthetic val$result_f:Lcom/google/payment/IabResult;


# direct methods
.method constructor <init>(Lcom/google/payment/IabHelper$2;Lcom/google/payment/IabResult;Lcom/google/payment/Inventory;)V
    .locals 0
    .param p1, "this$1"    # Lcom/google/payment/IabHelper$2;

    .prologue
    .line 797
    iput-object p1, p0, Lcom/google/payment/IabHelper$2$1;->this$1:Lcom/google/payment/IabHelper$2;

    iput-object p2, p0, Lcom/google/payment/IabHelper$2$1;->val$result_f:Lcom/google/payment/IabResult;

    iput-object p3, p0, Lcom/google/payment/IabHelper$2$1;->val$inv_f:Lcom/google/payment/Inventory;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 3

    .prologue
    .line 799
    iget-object v0, p0, Lcom/google/payment/IabHelper$2$1;->this$1:Lcom/google/payment/IabHelper$2;

    iget-object v0, v0, Lcom/google/payment/IabHelper$2;->val$listener:Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;

    iget-object v1, p0, Lcom/google/payment/IabHelper$2$1;->val$result_f:Lcom/google/payment/IabResult;

    iget-object v2, p0, Lcom/google/payment/IabHelper$2$1;->val$inv_f:Lcom/google/payment/Inventory;

    invoke-interface {v0, v1, v2}, Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;->onQueryInventoryFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Inventory;)V

    .line 800
    return-void
.end method
