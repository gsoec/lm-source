.class Lcom/google/payment/IabHelper$4$4;
.super Ljava/lang/Object;
.source "IabHelper.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/google/payment/IabHelper$4;->run()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/google/payment/IabHelper$4;


# direct methods
.method constructor <init>(Lcom/google/payment/IabHelper$4;)V
    .locals 0
    .param p1, "this$1"    # Lcom/google/payment/IabHelper$4;

    .prologue
    .line 942
    iput-object p1, p0, Lcom/google/payment/IabHelper$4$4;->this$1:Lcom/google/payment/IabHelper$4;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 3

    .prologue
    .line 944
    const-string v0, "queryInventoryAsync"

    const-string v1, "IGGError.NoneError()"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 945
    iget-object v0, p0, Lcom/google/payment/IabHelper$4$4;->this$1:Lcom/google/payment/IabHelper$4;

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$listener:Lcom/google/payment/IabHelper$QueryInventoryListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v1

    iget-object v2, p0, Lcom/google/payment/IabHelper$4$4;->this$1:Lcom/google/payment/IabHelper$4;

    iget-object v2, v2, Lcom/google/payment/IabHelper$4;->val$items:Ljava/util/ArrayList;

    invoke-interface {v0, v1, v2}, Lcom/google/payment/IabHelper$QueryInventoryListener;->onQueryInventoryFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    .line 946
    return-void
.end method
