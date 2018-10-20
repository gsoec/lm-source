.class Lcom/google/payment/IabHelper$3;
.super Ljava/lang/Object;
.source "IabHelper.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/google/payment/IabHelper;->queryInventoryAsync(Ljava/util/ArrayList;Lcom/google/payment/IabHelper$QueryInventoryListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/google/payment/IabHelper;

.field final synthetic val$listener:Lcom/google/payment/IabHelper$QueryInventoryListener;


# direct methods
.method constructor <init>(Lcom/google/payment/IabHelper;Lcom/google/payment/IabHelper$QueryInventoryListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/google/payment/IabHelper;

    .prologue
    .line 830
    iput-object p1, p0, Lcom/google/payment/IabHelper$3;->this$0:Lcom/google/payment/IabHelper;

    iput-object p2, p0, Lcom/google/payment/IabHelper$3;->val$listener:Lcom/google/payment/IabHelper$QueryInventoryListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 3

    .prologue
    const/4 v2, 0x0

    .line 832
    const-string v0, "queryInventoryAsync"

    const-string v1, "IGGError.remoteError(null)-1"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 833
    iget-object v0, p0, Lcom/google/payment/IabHelper$3;->val$listener:Lcom/google/payment/IabHelper$QueryInventoryListener;

    invoke-static {v2}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v1

    invoke-interface {v0, v1, v2}, Lcom/google/payment/IabHelper$QueryInventoryListener;->onQueryInventoryFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    .line 834
    return-void
.end method
