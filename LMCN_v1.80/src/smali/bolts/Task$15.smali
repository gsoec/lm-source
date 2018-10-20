.class final Lbolts/Task$15;
.super Ljava/lang/Object;
.source "Task.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lbolts/Task;->completeAfterTask(Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Lbolts/Task;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = null
.end annotation


# instance fields
.field final synthetic val$continuation:Lbolts/Continuation;

.field final synthetic val$ct:Lbolts/CancellationToken;

.field final synthetic val$task:Lbolts/Task;

.field final synthetic val$tcs:Lbolts/Task$TaskCompletionSource;


# direct methods
.method constructor <init>(Lbolts/CancellationToken;Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Lbolts/Task;)V
    .locals 0

    .prologue
    .line 816
    iput-object p1, p0, Lbolts/Task$15;->val$ct:Lbolts/CancellationToken;

    iput-object p2, p0, Lbolts/Task$15;->val$tcs:Lbolts/Task$TaskCompletionSource;

    iput-object p3, p0, Lbolts/Task$15;->val$continuation:Lbolts/Continuation;

    iput-object p4, p0, Lbolts/Task$15;->val$task:Lbolts/Task;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 4

    .prologue
    .line 819
    iget-object v2, p0, Lbolts/Task$15;->val$ct:Lbolts/CancellationToken;

    if-eqz v2, :cond_0

    iget-object v2, p0, Lbolts/Task$15;->val$ct:Lbolts/CancellationToken;

    invoke-virtual {v2}, Lbolts/CancellationToken;->isCancellationRequested()Z

    move-result v2

    if-eqz v2, :cond_0

    .line 820
    iget-object v2, p0, Lbolts/Task$15;->val$tcs:Lbolts/Task$TaskCompletionSource;

    invoke-virtual {v2}, Lbolts/Task$TaskCompletionSource;->setCancelled()V

    .line 853
    :goto_0
    return-void

    .line 825
    :cond_0
    :try_start_0
    iget-object v2, p0, Lbolts/Task$15;->val$continuation:Lbolts/Continuation;

    iget-object v3, p0, Lbolts/Task$15;->val$task:Lbolts/Task;

    invoke-interface {v2, v3}, Lbolts/Continuation;->then(Lbolts/Task;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lbolts/Task;

    .line 826
    .local v1, "result":Lbolts/Task;, "Lbolts/Task<TTContinuationResult;>;"
    if-nez v1, :cond_1

    .line 827
    iget-object v2, p0, Lbolts/Task$15;->val$tcs:Lbolts/Task$TaskCompletionSource;

    const/4 v3, 0x0

    invoke-virtual {v2, v3}, Lbolts/Task$TaskCompletionSource;->setResult(Ljava/lang/Object;)V
    :try_end_0
    .catch Ljava/util/concurrent/CancellationException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1

    goto :goto_0

    .line 848
    .end local v1    # "result":Lbolts/Task;, "Lbolts/Task<TTContinuationResult;>;"
    :catch_0
    move-exception v0

    .line 849
    .local v0, "e":Ljava/util/concurrent/CancellationException;
    iget-object v2, p0, Lbolts/Task$15;->val$tcs:Lbolts/Task$TaskCompletionSource;

    invoke-virtual {v2}, Lbolts/Task$TaskCompletionSource;->setCancelled()V

    goto :goto_0

    .line 829
    .end local v0    # "e":Ljava/util/concurrent/CancellationException;
    .restart local v1    # "result":Lbolts/Task;, "Lbolts/Task<TTContinuationResult;>;"
    :cond_1
    :try_start_1
    new-instance v2, Lbolts/Task$15$1;

    invoke-direct {v2, p0}, Lbolts/Task$15$1;-><init>(Lbolts/Task$15;)V

    invoke-virtual {v1, v2}, Lbolts/Task;->continueWith(Lbolts/Continuation;)Lbolts/Task;
    :try_end_1
    .catch Ljava/util/concurrent/CancellationException; {:try_start_1 .. :try_end_1} :catch_0
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    goto :goto_0

    .line 850
    .end local v1    # "result":Lbolts/Task;, "Lbolts/Task<TTContinuationResult;>;"
    :catch_1
    move-exception v0

    .line 851
    .local v0, "e":Ljava/lang/Exception;
    iget-object v2, p0, Lbolts/Task$15;->val$tcs:Lbolts/Task$TaskCompletionSource;

    invoke-virtual {v2, v0}, Lbolts/Task$TaskCompletionSource;->setError(Ljava/lang/Exception;)V

    goto :goto_0
.end method
