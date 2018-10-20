.class public Lbolts/Task;
.super Ljava/lang/Object;
.source "Task.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lbolts/Task$TaskCompletionSource;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "<TResult:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/lang/Object;"
    }
.end annotation


# static fields
.field public static final BACKGROUND_EXECUTOR:Ljava/util/concurrent/ExecutorService;

.field private static final IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

.field public static final UI_THREAD_EXECUTOR:Ljava/util/concurrent/Executor;


# instance fields
.field private cancelled:Z

.field private complete:Z

.field private continuations:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lbolts/Continuation",
            "<TTResult;",
            "Ljava/lang/Void;",
            ">;>;"
        }
    .end annotation
.end field

.field private error:Ljava/lang/Exception;

.field private final lock:Ljava/lang/Object;

.field private result:Ljava/lang/Object;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "TTResult;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 36
    invoke-static {}, Lbolts/BoltsExecutors;->background()Ljava/util/concurrent/ExecutorService;

    move-result-object v0

    sput-object v0, Lbolts/Task;->BACKGROUND_EXECUTOR:Ljava/util/concurrent/ExecutorService;

    .line 43
    invoke-static {}, Lbolts/BoltsExecutors;->immediate()Ljava/util/concurrent/Executor;

    move-result-object v0

    sput-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    .line 48
    invoke-static {}, Lbolts/AndroidExecutors;->uiThread()Ljava/util/concurrent/Executor;

    move-result-object v0

    sput-object v0, Lbolts/Task;->UI_THREAD_EXECUTOR:Ljava/util/concurrent/Executor;

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .prologue
    .line 57
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 50
    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    iput-object v0, p0, Lbolts/Task;->lock:Ljava/lang/Object;

    .line 58
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lbolts/Task;->continuations:Ljava/util/List;

    .line 59
    return-void
.end method

.method static synthetic access$100(Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Lbolts/Task;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)V
    .locals 0
    .param p0, "x0"    # Lbolts/Task$TaskCompletionSource;
    .param p1, "x1"    # Lbolts/Continuation;
    .param p2, "x2"    # Lbolts/Task;
    .param p3, "x3"    # Ljava/util/concurrent/Executor;
    .param p4, "x4"    # Lbolts/CancellationToken;

    .prologue
    .line 32
    invoke-static {p0, p1, p2, p3, p4}, Lbolts/Task;->completeImmediately(Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Lbolts/Task;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)V

    return-void
.end method

.method static synthetic access$200(Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Lbolts/Task;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)V
    .locals 0
    .param p0, "x0"    # Lbolts/Task$TaskCompletionSource;
    .param p1, "x1"    # Lbolts/Continuation;
    .param p2, "x2"    # Lbolts/Task;
    .param p3, "x3"    # Ljava/util/concurrent/Executor;
    .param p4, "x4"    # Lbolts/CancellationToken;

    .prologue
    .line 32
    invoke-static {p0, p1, p2, p3, p4}, Lbolts/Task;->completeAfterTask(Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Lbolts/Task;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)V

    return-void
.end method

.method static synthetic access$300(Lbolts/Task;)Ljava/lang/Object;
    .locals 1
    .param p0, "x0"    # Lbolts/Task;

    .prologue
    .line 32
    iget-object v0, p0, Lbolts/Task;->lock:Ljava/lang/Object;

    return-object v0
.end method

.method static synthetic access$400(Lbolts/Task;)Z
    .locals 1
    .param p0, "x0"    # Lbolts/Task;

    .prologue
    .line 32
    iget-boolean v0, p0, Lbolts/Task;->complete:Z

    return v0
.end method

.method static synthetic access$402(Lbolts/Task;Z)Z
    .locals 0
    .param p0, "x0"    # Lbolts/Task;
    .param p1, "x1"    # Z

    .prologue
    .line 32
    iput-boolean p1, p0, Lbolts/Task;->complete:Z

    return p1
.end method

.method static synthetic access$502(Lbolts/Task;Z)Z
    .locals 0
    .param p0, "x0"    # Lbolts/Task;
    .param p1, "x1"    # Z

    .prologue
    .line 32
    iput-boolean p1, p0, Lbolts/Task;->cancelled:Z

    return p1
.end method

.method static synthetic access$600(Lbolts/Task;)V
    .locals 0
    .param p0, "x0"    # Lbolts/Task;

    .prologue
    .line 32
    invoke-direct {p0}, Lbolts/Task;->runContinuations()V

    return-void
.end method

.method static synthetic access$702(Lbolts/Task;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0
    .param p0, "x0"    # Lbolts/Task;
    .param p1, "x1"    # Ljava/lang/Object;

    .prologue
    .line 32
    iput-object p1, p0, Lbolts/Task;->result:Ljava/lang/Object;

    return-object p1
.end method

.method static synthetic access$802(Lbolts/Task;Ljava/lang/Exception;)Ljava/lang/Exception;
    .locals 0
    .param p0, "x0"    # Lbolts/Task;
    .param p1, "x1"    # Ljava/lang/Exception;

    .prologue
    .line 32
    iput-object p1, p0, Lbolts/Task;->error:Ljava/lang/Exception;

    return-object p1
.end method

.method public static call(Ljava/util/concurrent/Callable;)Lbolts/Task;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TResult:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/util/concurrent/Callable",
            "<TTResult;>;)",
            "Lbolts/Task",
            "<TTResult;>;"
        }
    .end annotation

    .prologue
    .line 296
    .local p0, "callable":Ljava/util/concurrent/Callable;, "Ljava/util/concurrent/Callable<TTResult;>;"
    sget-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x0

    invoke-static {p0, v0, v1}, Lbolts/Task;->call(Ljava/util/concurrent/Callable;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public static call(Ljava/util/concurrent/Callable;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 1
    .param p1, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TResult:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/util/concurrent/Callable",
            "<TTResult;>;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<TTResult;>;"
        }
    .end annotation

    .prologue
    .line 303
    .local p0, "callable":Ljava/util/concurrent/Callable;, "Ljava/util/concurrent/Callable<TTResult;>;"
    sget-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    invoke-static {p0, v0, p1}, Lbolts/Task;->call(Ljava/util/concurrent/Callable;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public static call(Ljava/util/concurrent/Callable;Ljava/util/concurrent/Executor;)Lbolts/Task;
    .locals 1
    .param p1, "executor"    # Ljava/util/concurrent/Executor;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TResult:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/util/concurrent/Callable",
            "<TTResult;>;",
            "Ljava/util/concurrent/Executor;",
            ")",
            "Lbolts/Task",
            "<TTResult;>;"
        }
    .end annotation

    .prologue
    .line 260
    .local p0, "callable":Ljava/util/concurrent/Callable;, "Ljava/util/concurrent/Callable<TTResult;>;"
    const/4 v0, 0x0

    invoke-static {p0, p1, v0}, Lbolts/Task;->call(Ljava/util/concurrent/Callable;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public static call(Ljava/util/concurrent/Callable;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 2
    .param p1, "executor"    # Ljava/util/concurrent/Executor;
    .param p2, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TResult:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/util/concurrent/Callable",
            "<TTResult;>;",
            "Ljava/util/concurrent/Executor;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<TTResult;>;"
        }
    .end annotation

    .prologue
    .line 268
    .local p0, "callable":Ljava/util/concurrent/Callable;, "Ljava/util/concurrent/Callable<TTResult;>;"
    invoke-static {}, Lbolts/Task;->create()Lbolts/Task$TaskCompletionSource;

    move-result-object v0

    .line 269
    .local v0, "tcs":Lbolts/Task$TaskCompletionSource;, "Lbolts/Task<TTResult;>.TaskCompletionSource;"
    new-instance v1, Lbolts/Task$4;

    invoke-direct {v1, p2, v0, p0}, Lbolts/Task$4;-><init>(Lbolts/CancellationToken;Lbolts/Task$TaskCompletionSource;Ljava/util/concurrent/Callable;)V

    invoke-interface {p1, v1}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    .line 286
    invoke-virtual {v0}, Lbolts/Task$TaskCompletionSource;->getTask()Lbolts/Task;

    move-result-object v1

    return-object v1
.end method

.method public static callInBackground(Ljava/util/concurrent/Callable;)Lbolts/Task;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TResult:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/util/concurrent/Callable",
            "<TTResult;>;)",
            "Lbolts/Task",
            "<TTResult;>;"
        }
    .end annotation

    .prologue
    .line 243
    .local p0, "callable":Ljava/util/concurrent/Callable;, "Ljava/util/concurrent/Callable<TTResult;>;"
    sget-object v0, Lbolts/Task;->BACKGROUND_EXECUTOR:Ljava/util/concurrent/ExecutorService;

    const/4 v1, 0x0

    invoke-static {p0, v0, v1}, Lbolts/Task;->call(Ljava/util/concurrent/Callable;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public static callInBackground(Ljava/util/concurrent/Callable;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 1
    .param p1, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TResult:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/util/concurrent/Callable",
            "<TTResult;>;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<TTResult;>;"
        }
    .end annotation

    .prologue
    .line 250
    .local p0, "callable":Ljava/util/concurrent/Callable;, "Ljava/util/concurrent/Callable<TTResult;>;"
    sget-object v0, Lbolts/Task;->BACKGROUND_EXECUTOR:Ljava/util/concurrent/ExecutorService;

    invoke-static {p0, v0, p1}, Lbolts/Task;->call(Ljava/util/concurrent/Callable;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public static cancelled()Lbolts/Task;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TResult:",
            "Ljava/lang/Object;",
            ">()",
            "Lbolts/Task",
            "<TTResult;>;"
        }
    .end annotation

    .prologue
    .line 151
    invoke-static {}, Lbolts/Task;->create()Lbolts/Task$TaskCompletionSource;

    move-result-object v0

    .line 152
    .local v0, "tcs":Lbolts/Task$TaskCompletionSource;, "Lbolts/Task<TTResult;>.TaskCompletionSource;"
    invoke-virtual {v0}, Lbolts/Task$TaskCompletionSource;->setCancelled()V

    .line 153
    invoke-virtual {v0}, Lbolts/Task$TaskCompletionSource;->getTask()Lbolts/Task;

    move-result-object v1

    return-object v1
.end method

.method private static completeAfterTask(Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Lbolts/Task;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)V
    .locals 1
    .param p3, "executor"    # Ljava/util/concurrent/Executor;
    .param p4, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            "TResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Task",
            "<TTContinuationResult;>.TaskCompletionSource;",
            "Lbolts/Continuation",
            "<TTResult;",
            "Lbolts/Task",
            "<TTContinuationResult;>;>;",
            "Lbolts/Task",
            "<TTResult;>;",
            "Ljava/util/concurrent/Executor;",
            "Lbolts/CancellationToken;",
            ")V"
        }
    .end annotation

    .prologue
    .line 816
    .local p0, "tcs":Lbolts/Task$TaskCompletionSource;, "Lbolts/Task<TTContinuationResult;>.TaskCompletionSource;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;Lbolts/Task<TTContinuationResult;>;>;"
    .local p2, "task":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    new-instance v0, Lbolts/Task$15;

    invoke-direct {v0, p4, p0, p1, p2}, Lbolts/Task$15;-><init>(Lbolts/CancellationToken;Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Lbolts/Task;)V

    invoke-interface {p3, v0}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    .line 855
    return-void
.end method

.method private static completeImmediately(Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Lbolts/Task;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)V
    .locals 1
    .param p3, "executor"    # Ljava/util/concurrent/Executor;
    .param p4, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            "TResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Task",
            "<TTContinuationResult;>.TaskCompletionSource;",
            "Lbolts/Continuation",
            "<TTResult;TTContinuationResult;>;",
            "Lbolts/Task",
            "<TTResult;>;",
            "Ljava/util/concurrent/Executor;",
            "Lbolts/CancellationToken;",
            ")V"
        }
    .end annotation

    .prologue
    .line 775
    .local p0, "tcs":Lbolts/Task$TaskCompletionSource;, "Lbolts/Task<TTContinuationResult;>.TaskCompletionSource;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;TTContinuationResult;>;"
    .local p2, "task":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    new-instance v0, Lbolts/Task$14;

    invoke-direct {v0, p4, p0, p1, p2}, Lbolts/Task$14;-><init>(Lbolts/CancellationToken;Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Lbolts/Task;)V

    invoke-interface {p3, v0}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    .line 793
    return-void
.end method

.method public static create()Lbolts/Task$TaskCompletionSource;
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TResult:",
            "Ljava/lang/Object;",
            ">()",
            "Lbolts/Task",
            "<TTResult;>.TaskCompletionSource;"
        }
    .end annotation

    .prologue
    .line 68
    new-instance v0, Lbolts/Task;

    invoke-direct {v0}, Lbolts/Task;-><init>()V

    .line 69
    .local v0, "task":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    new-instance v1, Lbolts/Task$TaskCompletionSource;

    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    const/4 v2, 0x0

    invoke-direct {v1, v0, v2}, Lbolts/Task$TaskCompletionSource;-><init>(Lbolts/Task;Lbolts/Task$1;)V

    return-object v1
.end method

.method public static delay(J)Lbolts/Task;
    .locals 2
    .param p0, "delay"    # J
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J)",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;"
        }
    .end annotation

    .prologue
    .line 163
    invoke-static {}, Lbolts/BoltsExecutors;->scheduled()Ljava/util/concurrent/ScheduledExecutorService;

    move-result-object v0

    const/4 v1, 0x0

    invoke-static {p0, p1, v0, v1}, Lbolts/Task;->delay(JLjava/util/concurrent/ScheduledExecutorService;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public static delay(JLbolts/CancellationToken;)Lbolts/Task;
    .locals 2
    .param p0, "delay"    # J
    .param p2, "cancellationToken"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;"
        }
    .end annotation

    .prologue
    .line 175
    invoke-static {}, Lbolts/BoltsExecutors;->scheduled()Ljava/util/concurrent/ScheduledExecutorService;

    move-result-object v0

    invoke-static {p0, p1, v0, p2}, Lbolts/Task;->delay(JLjava/util/concurrent/ScheduledExecutorService;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method static delay(JLjava/util/concurrent/ScheduledExecutorService;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 4
    .param p0, "delay"    # J
    .param p2, "executor"    # Ljava/util/concurrent/ScheduledExecutorService;
    .param p3, "cancellationToken"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J",
            "Ljava/util/concurrent/ScheduledExecutorService;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;"
        }
    .end annotation

    .prologue
    .line 179
    if-eqz p3, :cond_0

    invoke-virtual {p3}, Lbolts/CancellationToken;->isCancellationRequested()Z

    move-result v2

    if-eqz v2, :cond_0

    .line 180
    invoke-static {}, Lbolts/Task;->cancelled()Lbolts/Task;

    move-result-object v2

    .line 205
    :goto_0
    return-object v2

    .line 183
    :cond_0
    const-wide/16 v2, 0x0

    cmp-long v2, p0, v2

    if-gtz v2, :cond_1

    .line 184
    const/4 v2, 0x0

    invoke-static {v2}, Lbolts/Task;->forResult(Ljava/lang/Object;)Lbolts/Task;

    move-result-object v2

    goto :goto_0

    .line 187
    :cond_1
    invoke-static {}, Lbolts/Task;->create()Lbolts/Task$TaskCompletionSource;

    move-result-object v1

    .line 188
    .local v1, "tcs":Lbolts/Task$TaskCompletionSource;, "Lbolts/Task<Ljava/lang/Void;>.TaskCompletionSource;"
    new-instance v2, Lbolts/Task$1;

    invoke-direct {v2, v1}, Lbolts/Task$1;-><init>(Lbolts/Task$TaskCompletionSource;)V

    sget-object v3, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-interface {p2, v2, p0, p1, v3}, Ljava/util/concurrent/ScheduledExecutorService;->schedule(Ljava/lang/Runnable;JLjava/util/concurrent/TimeUnit;)Ljava/util/concurrent/ScheduledFuture;

    move-result-object v0

    .line 195
    .local v0, "scheduled":Ljava/util/concurrent/ScheduledFuture;, "Ljava/util/concurrent/ScheduledFuture<*>;"
    if-eqz p3, :cond_2

    .line 196
    new-instance v2, Lbolts/Task$2;

    invoke-direct {v2, v0, v1}, Lbolts/Task$2;-><init>(Ljava/util/concurrent/ScheduledFuture;Lbolts/Task$TaskCompletionSource;)V

    invoke-virtual {p3, v2}, Lbolts/CancellationToken;->register(Ljava/lang/Runnable;)Lbolts/CancellationTokenRegistration;

    .line 205
    :cond_2
    invoke-virtual {v1}, Lbolts/Task$TaskCompletionSource;->getTask()Lbolts/Task;

    move-result-object v2

    goto :goto_0
.end method

.method public static forError(Ljava/lang/Exception;)Lbolts/Task;
    .locals 2
    .param p0, "error"    # Ljava/lang/Exception;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TResult:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/lang/Exception;",
            ")",
            "Lbolts/Task",
            "<TTResult;>;"
        }
    .end annotation

    .prologue
    .line 142
    invoke-static {}, Lbolts/Task;->create()Lbolts/Task$TaskCompletionSource;

    move-result-object v0

    .line 143
    .local v0, "tcs":Lbolts/Task$TaskCompletionSource;, "Lbolts/Task<TTResult;>.TaskCompletionSource;"
    invoke-virtual {v0, p0}, Lbolts/Task$TaskCompletionSource;->setError(Ljava/lang/Exception;)V

    .line 144
    invoke-virtual {v0}, Lbolts/Task$TaskCompletionSource;->getTask()Lbolts/Task;

    move-result-object v1

    return-object v1
.end method

.method public static forResult(Ljava/lang/Object;)Lbolts/Task;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TResult:",
            "Ljava/lang/Object;",
            ">(TTResult;)",
            "Lbolts/Task",
            "<TTResult;>;"
        }
    .end annotation

    .prologue
    .line 133
    .local p0, "value":Ljava/lang/Object;, "TTResult;"
    invoke-static {}, Lbolts/Task;->create()Lbolts/Task$TaskCompletionSource;

    move-result-object v0

    .line 134
    .local v0, "tcs":Lbolts/Task$TaskCompletionSource;, "Lbolts/Task<TTResult;>.TaskCompletionSource;"
    invoke-virtual {v0, p0}, Lbolts/Task$TaskCompletionSource;->setResult(Ljava/lang/Object;)V

    .line 135
    invoke-virtual {v0}, Lbolts/Task$TaskCompletionSource;->getTask()Lbolts/Task;

    move-result-object v1

    return-object v1
.end method

.method private runContinuations()V
    .locals 5

    .prologue
    .line 858
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    iget-object v4, p0, Lbolts/Task;->lock:Ljava/lang/Object;

    monitor-enter v4

    .line 859
    :try_start_0
    iget-object v3, p0, Lbolts/Task;->continuations:Ljava/util/List;

    invoke-interface {v3}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v2

    .local v2, "i$":Ljava/util/Iterator;
    :goto_0
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_0

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lbolts/Continuation;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 861
    .local v0, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;*>;"
    :try_start_1
    invoke-interface {v0, p0}, Lbolts/Continuation;->then(Lbolts/Task;)Ljava/lang/Object;
    :try_end_1
    .catch Ljava/lang/RuntimeException; {:try_start_1 .. :try_end_1} :catch_0
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_0

    .line 862
    :catch_0
    move-exception v1

    .line 863
    .local v1, "e":Ljava/lang/RuntimeException;
    :try_start_2
    throw v1

    .line 869
    .end local v0    # "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;*>;"
    .end local v1    # "e":Ljava/lang/RuntimeException;
    .end local v2    # "i$":Ljava/util/Iterator;
    :catchall_0
    move-exception v3

    monitor-exit v4
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    throw v3

    .line 864
    .restart local v0    # "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;*>;"
    .restart local v2    # "i$":Ljava/util/Iterator;
    :catch_1
    move-exception v1

    .line 865
    .local v1, "e":Ljava/lang/Exception;
    :try_start_3
    new-instance v3, Ljava/lang/RuntimeException;

    invoke-direct {v3, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/Throwable;)V

    throw v3

    .line 868
    .end local v0    # "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;*>;"
    .end local v1    # "e":Ljava/lang/Exception;
    :cond_0
    const/4 v3, 0x0

    iput-object v3, p0, Lbolts/Task;->continuations:Ljava/util/List;

    .line 869
    monitor-exit v4
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    .line 870
    return-void
.end method

.method public static whenAll(Ljava/util/Collection;)Lbolts/Task;
    .locals 9
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Collection",
            "<+",
            "Lbolts/Task",
            "<*>;>;)",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;"
        }
    .end annotation

    .prologue
    .line 438
    .local p0, "tasks":Ljava/util/Collection;, "Ljava/util/Collection<+Lbolts/Task<*>;>;"
    invoke-interface {p0}, Ljava/util/Collection;->size()I

    move-result v0

    if-nez v0, :cond_0

    .line 439
    const/4 v0, 0x0

    invoke-static {v0}, Lbolts/Task;->forResult(Ljava/lang/Object;)Lbolts/Task;

    move-result-object v0

    .line 485
    :goto_0
    return-object v0

    .line 442
    :cond_0
    invoke-static {}, Lbolts/Task;->create()Lbolts/Task$TaskCompletionSource;

    move-result-object v5

    .line 443
    .local v5, "allFinished":Lbolts/Task$TaskCompletionSource;, "Lbolts/Task<Ljava/lang/Void;>.TaskCompletionSource;"
    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    .line 444
    .local v2, "causes":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/Exception;>;"
    new-instance v1, Ljava/lang/Object;

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    .line 445
    .local v1, "errorLock":Ljava/lang/Object;
    new-instance v4, Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-interface {p0}, Ljava/util/Collection;->size()I

    move-result v0

    invoke-direct {v4, v0}, Ljava/util/concurrent/atomic/AtomicInteger;-><init>(I)V

    .line 446
    .local v4, "count":Ljava/util/concurrent/atomic/AtomicInteger;
    new-instance v3, Ljava/util/concurrent/atomic/AtomicBoolean;

    const/4 v0, 0x0

    invoke-direct {v3, v0}, Ljava/util/concurrent/atomic/AtomicBoolean;-><init>(Z)V

    .line 448
    .local v3, "isCancelled":Ljava/util/concurrent/atomic/AtomicBoolean;
    invoke-interface {p0}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object v6

    .local v6, "i$":Ljava/util/Iterator;
    :goto_1
    invoke-interface {v6}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v6}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Lbolts/Task;

    .line 450
    .local v8, "task":Lbolts/Task;, "Lbolts/Task<*>;"
    move-object v7, v8

    .line 451
    .local v7, "t":Lbolts/Task;, "Lbolts/Task<Ljava/lang/Object;>;"
    new-instance v0, Lbolts/Task$8;

    invoke-direct/range {v0 .. v5}, Lbolts/Task$8;-><init>(Ljava/lang/Object;Ljava/util/ArrayList;Ljava/util/concurrent/atomic/AtomicBoolean;Ljava/util/concurrent/atomic/AtomicInteger;Lbolts/Task$TaskCompletionSource;)V

    invoke-virtual {v7, v0}, Lbolts/Task;->continueWith(Lbolts/Continuation;)Lbolts/Task;

    goto :goto_1

    .line 485
    .end local v7    # "t":Lbolts/Task;, "Lbolts/Task<Ljava/lang/Object;>;"
    .end local v8    # "task":Lbolts/Task;, "Lbolts/Task<*>;"
    :cond_1
    invoke-virtual {v5}, Lbolts/Task$TaskCompletionSource;->getTask()Lbolts/Task;

    move-result-object v0

    goto :goto_0
.end method

.method public static whenAllResult(Ljava/util/Collection;)Lbolts/Task;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TResult:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/util/Collection",
            "<+",
            "Lbolts/Task",
            "<TTResult;>;>;)",
            "Lbolts/Task",
            "<",
            "Ljava/util/List",
            "<TTResult;>;>;"
        }
    .end annotation

    .prologue
    .line 401
    .local p0, "tasks":Ljava/util/Collection;, "Ljava/util/Collection<+Lbolts/Task<TTResult;>;>;"
    invoke-static {p0}, Lbolts/Task;->whenAll(Ljava/util/Collection;)Lbolts/Task;

    move-result-object v0

    new-instance v1, Lbolts/Task$7;

    invoke-direct {v1, p0}, Lbolts/Task$7;-><init>(Ljava/util/Collection;)V

    invoke-virtual {v0, v1}, Lbolts/Task;->onSuccess(Lbolts/Continuation;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public static whenAny(Ljava/util/Collection;)Lbolts/Task;
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Collection",
            "<+",
            "Lbolts/Task",
            "<*>;>;)",
            "Lbolts/Task",
            "<",
            "Lbolts/Task",
            "<*>;>;"
        }
    .end annotation

    .prologue
    .line 354
    .local p0, "tasks":Ljava/util/Collection;, "Ljava/util/Collection<+Lbolts/Task<*>;>;"
    invoke-interface {p0}, Ljava/util/Collection;->size()I

    move-result v4

    if-nez v4, :cond_0

    .line 355
    const/4 v4, 0x0

    invoke-static {v4}, Lbolts/Task;->forResult(Ljava/lang/Object;)Lbolts/Task;

    move-result-object v4

    .line 372
    :goto_0
    return-object v4

    .line 358
    :cond_0
    invoke-static {}, Lbolts/Task;->create()Lbolts/Task$TaskCompletionSource;

    move-result-object v0

    .line 359
    .local v0, "firstCompleted":Lbolts/Task$TaskCompletionSource;, "Lbolts/Task<Lbolts/Task<*>;>.TaskCompletionSource;"
    new-instance v2, Ljava/util/concurrent/atomic/AtomicBoolean;

    const/4 v4, 0x0

    invoke-direct {v2, v4}, Ljava/util/concurrent/atomic/AtomicBoolean;-><init>(Z)V

    .line 361
    .local v2, "isAnyTaskComplete":Ljava/util/concurrent/atomic/AtomicBoolean;
    invoke-interface {p0}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object v1

    .local v1, "i$":Ljava/util/Iterator;
    :goto_1
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v4

    if-eqz v4, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lbolts/Task;

    .line 362
    .local v3, "task":Lbolts/Task;, "Lbolts/Task<*>;"
    new-instance v4, Lbolts/Task$6;

    invoke-direct {v4, v2, v0}, Lbolts/Task$6;-><init>(Ljava/util/concurrent/atomic/AtomicBoolean;Lbolts/Task$TaskCompletionSource;)V

    invoke-virtual {v3, v4}, Lbolts/Task;->continueWith(Lbolts/Continuation;)Lbolts/Task;

    goto :goto_1

    .line 372
    .end local v3    # "task":Lbolts/Task;, "Lbolts/Task<*>;"
    :cond_1
    invoke-virtual {v0}, Lbolts/Task$TaskCompletionSource;->getTask()Lbolts/Task;

    move-result-object v4

    goto :goto_0
.end method

.method public static whenAnyResult(Ljava/util/Collection;)Lbolts/Task;
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TResult:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/util/Collection",
            "<+",
            "Lbolts/Task",
            "<TTResult;>;>;)",
            "Lbolts/Task",
            "<",
            "Lbolts/Task",
            "<TTResult;>;>;"
        }
    .end annotation

    .prologue
    .line 319
    .local p0, "tasks":Ljava/util/Collection;, "Ljava/util/Collection<+Lbolts/Task<TTResult;>;>;"
    invoke-interface {p0}, Ljava/util/Collection;->size()I

    move-result v4

    if-nez v4, :cond_0

    .line 320
    const/4 v4, 0x0

    invoke-static {v4}, Lbolts/Task;->forResult(Ljava/lang/Object;)Lbolts/Task;

    move-result-object v4

    .line 337
    :goto_0
    return-object v4

    .line 323
    :cond_0
    invoke-static {}, Lbolts/Task;->create()Lbolts/Task$TaskCompletionSource;

    move-result-object v0

    .line 324
    .local v0, "firstCompleted":Lbolts/Task$TaskCompletionSource;, "Lbolts/Task<Lbolts/Task<TTResult;>;>.TaskCompletionSource;"
    new-instance v2, Ljava/util/concurrent/atomic/AtomicBoolean;

    const/4 v4, 0x0

    invoke-direct {v2, v4}, Ljava/util/concurrent/atomic/AtomicBoolean;-><init>(Z)V

    .line 326
    .local v2, "isAnyTaskComplete":Ljava/util/concurrent/atomic/AtomicBoolean;
    invoke-interface {p0}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object v1

    .local v1, "i$":Ljava/util/Iterator;
    :goto_1
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v4

    if-eqz v4, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lbolts/Task;

    .line 327
    .local v3, "task":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    new-instance v4, Lbolts/Task$5;

    invoke-direct {v4, v2, v0}, Lbolts/Task$5;-><init>(Ljava/util/concurrent/atomic/AtomicBoolean;Lbolts/Task$TaskCompletionSource;)V

    invoke-virtual {v3, v4}, Lbolts/Task;->continueWith(Lbolts/Continuation;)Lbolts/Task;

    goto :goto_1

    .line 337
    .end local v3    # "task":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    :cond_1
    invoke-virtual {v0}, Lbolts/Task$TaskCompletionSource;->getTask()Lbolts/Task;

    move-result-object v4

    goto :goto_0
.end method


# virtual methods
.method public cast()Lbolts/Task;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TOut:",
            "Ljava/lang/Object;",
            ">()",
            "Lbolts/Task",
            "<TTOut;>;"
        }
    .end annotation

    .prologue
    .line 214
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    move-object v0, p0

    .line 215
    .local v0, "task":Lbolts/Task;, "Lbolts/Task<TTOut;>;"
    return-object v0
.end method

.method public continueWhile(Ljava/util/concurrent/Callable;Lbolts/Continuation;)Lbolts/Task;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/concurrent/Callable",
            "<",
            "Ljava/lang/Boolean;",
            ">;",
            "Lbolts/Continuation",
            "<",
            "Ljava/lang/Void;",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;>;)",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;"
        }
    .end annotation

    .prologue
    .line 494
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "predicate":Ljava/util/concurrent/Callable;, "Ljava/util/concurrent/Callable<Ljava/lang/Boolean;>;"
    .local p2, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<Ljava/lang/Void;Lbolts/Task<Ljava/lang/Void;>;>;"
    sget-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x0

    invoke-virtual {p0, p1, p2, v0, v1}, Lbolts/Task;->continueWhile(Ljava/util/concurrent/Callable;Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public continueWhile(Ljava/util/concurrent/Callable;Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 1
    .param p3, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/concurrent/Callable",
            "<",
            "Ljava/lang/Boolean;",
            ">;",
            "Lbolts/Continuation",
            "<",
            "Ljava/lang/Void;",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;>;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;"
        }
    .end annotation

    .prologue
    .line 503
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "predicate":Ljava/util/concurrent/Callable;, "Ljava/util/concurrent/Callable<Ljava/lang/Boolean;>;"
    .local p2, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<Ljava/lang/Void;Lbolts/Task<Ljava/lang/Void;>;>;"
    sget-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    invoke-virtual {p0, p1, p2, v0, p3}, Lbolts/Task;->continueWhile(Ljava/util/concurrent/Callable;Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public continueWhile(Ljava/util/concurrent/Callable;Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;
    .locals 1
    .param p3, "executor"    # Ljava/util/concurrent/Executor;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/concurrent/Callable",
            "<",
            "Ljava/lang/Boolean;",
            ">;",
            "Lbolts/Continuation",
            "<",
            "Ljava/lang/Void;",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;>;",
            "Ljava/util/concurrent/Executor;",
            ")",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;"
        }
    .end annotation

    .prologue
    .line 512
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "predicate":Ljava/util/concurrent/Callable;, "Ljava/util/concurrent/Callable<Ljava/lang/Boolean;>;"
    .local p2, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<Ljava/lang/Void;Lbolts/Task<Ljava/lang/Void;>;>;"
    const/4 v0, 0x0

    invoke-virtual {p0, p1, p2, p3, v0}, Lbolts/Task;->continueWhile(Ljava/util/concurrent/Callable;Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public continueWhile(Ljava/util/concurrent/Callable;Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 7
    .param p3, "executor"    # Ljava/util/concurrent/Executor;
    .param p4, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/concurrent/Callable",
            "<",
            "Ljava/lang/Boolean;",
            ">;",
            "Lbolts/Continuation",
            "<",
            "Ljava/lang/Void;",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;>;",
            "Ljava/util/concurrent/Executor;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;"
        }
    .end annotation

    .prologue
    .line 522
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "predicate":Ljava/util/concurrent/Callable;, "Ljava/util/concurrent/Callable<Ljava/lang/Boolean;>;"
    .local p2, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<Ljava/lang/Void;Lbolts/Task<Ljava/lang/Void;>;>;"
    new-instance v6, Lbolts/Capture;

    invoke-direct {v6}, Lbolts/Capture;-><init>()V

    .line 524
    .local v6, "predicateContinuation":Lbolts/Capture;, "Lbolts/Capture<Lbolts/Continuation<Ljava/lang/Void;Lbolts/Task<Ljava/lang/Void;>;>;>;"
    new-instance v0, Lbolts/Task$9;

    move-object v1, p0

    move-object v2, p4

    move-object v3, p1

    move-object v4, p2

    move-object v5, p3

    invoke-direct/range {v0 .. v6}, Lbolts/Task$9;-><init>(Lbolts/Task;Lbolts/CancellationToken;Ljava/util/concurrent/Callable;Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/Capture;)V

    invoke-virtual {v6, v0}, Lbolts/Capture;->set(Ljava/lang/Object;)V

    .line 538
    invoke-virtual {p0}, Lbolts/Task;->makeVoid()Lbolts/Task;

    move-result-object v1

    invoke-virtual {v6}, Lbolts/Capture;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lbolts/Continuation;

    invoke-virtual {v1, v0, p3}, Lbolts/Task;->continueWithTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public continueWith(Lbolts/Continuation;)Lbolts/Task;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;TTContinuationResult;>;)",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 585
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;TTContinuationResult;>;"
    sget-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x0

    invoke-virtual {p0, p1, v0, v1}, Lbolts/Task;->continueWith(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public continueWith(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 1
    .param p2, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;TTContinuationResult;>;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 594
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;TTContinuationResult;>;"
    sget-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    invoke-virtual {p0, p1, v0, p2}, Lbolts/Task;->continueWith(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public continueWith(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;
    .locals 1
    .param p2, "executor"    # Ljava/util/concurrent/Executor;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;TTContinuationResult;>;",
            "Ljava/util/concurrent/Executor;",
            ")",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 548
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;TTContinuationResult;>;"
    const/4 v0, 0x0

    invoke-virtual {p0, p1, p2, v0}, Lbolts/Task;->continueWith(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public continueWith(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 9
    .param p2, "executor"    # Ljava/util/concurrent/Executor;
    .param p3, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;TTContinuationResult;>;",
            "Ljava/util/concurrent/Executor;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 560
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;TTContinuationResult;>;"
    invoke-static {}, Lbolts/Task;->create()Lbolts/Task$TaskCompletionSource;

    move-result-object v2

    .line 561
    .local v2, "tcs":Lbolts/Task$TaskCompletionSource;, "Lbolts/Task<TTContinuationResult;>.TaskCompletionSource;"
    iget-object v7, p0, Lbolts/Task;->lock:Ljava/lang/Object;

    monitor-enter v7

    .line 562
    :try_start_0
    invoke-virtual {p0}, Lbolts/Task;->isCompleted()Z

    move-result v6

    .line 563
    .local v6, "completed":Z
    if-nez v6, :cond_0

    .line 564
    iget-object v8, p0, Lbolts/Task;->continuations:Ljava/util/List;

    new-instance v0, Lbolts/Task$10;

    move-object v1, p0

    move-object v3, p1

    move-object v4, p2

    move-object v5, p3

    invoke-direct/range {v0 .. v5}, Lbolts/Task$10;-><init>(Lbolts/Task;Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)V

    invoke-interface {v8, v0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 572
    :cond_0
    monitor-exit v7
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 573
    if-eqz v6, :cond_1

    .line 574
    invoke-static {v2, p1, p0, p2, p3}, Lbolts/Task;->completeImmediately(Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Lbolts/Task;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)V

    .line 576
    :cond_1
    invoke-virtual {v2}, Lbolts/Task$TaskCompletionSource;->getTask()Lbolts/Task;

    move-result-object v0

    return-object v0

    .line 572
    .end local v6    # "completed":Z
    :catchall_0
    move-exception v0

    :try_start_1
    monitor-exit v7
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0
.end method

.method public continueWithTask(Lbolts/Continuation;)Lbolts/Task;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;",
            "Lbolts/Task",
            "<TTContinuationResult;>;>;)",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 639
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;Lbolts/Task<TTContinuationResult;>;>;"
    sget-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x0

    invoke-virtual {p0, p1, v0, v1}, Lbolts/Task;->continueWithTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public continueWithTask(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 1
    .param p2, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;",
            "Lbolts/Task",
            "<TTContinuationResult;>;>;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 648
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;Lbolts/Task<TTContinuationResult;>;>;"
    sget-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    invoke-virtual {p0, p1, v0, p2}, Lbolts/Task;->continueWithTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public continueWithTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;
    .locals 1
    .param p2, "executor"    # Ljava/util/concurrent/Executor;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;",
            "Lbolts/Task",
            "<TTContinuationResult;>;>;",
            "Ljava/util/concurrent/Executor;",
            ")",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 603
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;Lbolts/Task<TTContinuationResult;>;>;"
    const/4 v0, 0x0

    invoke-virtual {p0, p1, p2, v0}, Lbolts/Task;->continueWithTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public continueWithTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 9
    .param p2, "executor"    # Ljava/util/concurrent/Executor;
    .param p3, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;",
            "Lbolts/Task",
            "<TTContinuationResult;>;>;",
            "Ljava/util/concurrent/Executor;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 614
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;Lbolts/Task<TTContinuationResult;>;>;"
    invoke-static {}, Lbolts/Task;->create()Lbolts/Task$TaskCompletionSource;

    move-result-object v2

    .line 615
    .local v2, "tcs":Lbolts/Task$TaskCompletionSource;, "Lbolts/Task<TTContinuationResult;>.TaskCompletionSource;"
    iget-object v7, p0, Lbolts/Task;->lock:Ljava/lang/Object;

    monitor-enter v7

    .line 616
    :try_start_0
    invoke-virtual {p0}, Lbolts/Task;->isCompleted()Z

    move-result v6

    .line 617
    .local v6, "completed":Z
    if-nez v6, :cond_0

    .line 618
    iget-object v8, p0, Lbolts/Task;->continuations:Ljava/util/List;

    new-instance v0, Lbolts/Task$11;

    move-object v1, p0

    move-object v3, p1

    move-object v4, p2

    move-object v5, p3

    invoke-direct/range {v0 .. v5}, Lbolts/Task$11;-><init>(Lbolts/Task;Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)V

    invoke-interface {v8, v0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 626
    :cond_0
    monitor-exit v7
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 627
    if-eqz v6, :cond_1

    .line 628
    invoke-static {v2, p1, p0, p2, p3}, Lbolts/Task;->completeAfterTask(Lbolts/Task$TaskCompletionSource;Lbolts/Continuation;Lbolts/Task;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)V

    .line 630
    :cond_1
    invoke-virtual {v2}, Lbolts/Task$TaskCompletionSource;->getTask()Lbolts/Task;

    move-result-object v0

    return-object v0

    .line 626
    .end local v6    # "completed":Z
    :catchall_0
    move-exception v0

    :try_start_1
    monitor-exit v7
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0
.end method

.method public getError()Ljava/lang/Exception;
    .locals 2

    .prologue
    .line 113
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    iget-object v1, p0, Lbolts/Task;->lock:Ljava/lang/Object;

    monitor-enter v1

    .line 114
    :try_start_0
    iget-object v0, p0, Lbolts/Task;->error:Ljava/lang/Exception;

    monitor-exit v1

    return-object v0

    .line 115
    :catchall_0
    move-exception v0

    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public getResult()Ljava/lang/Object;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()TTResult;"
        }
    .end annotation

    .prologue
    .line 104
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    iget-object v1, p0, Lbolts/Task;->lock:Ljava/lang/Object;

    monitor-enter v1

    .line 105
    :try_start_0
    iget-object v0, p0, Lbolts/Task;->result:Ljava/lang/Object;

    monitor-exit v1

    return-object v0

    .line 106
    :catchall_0
    move-exception v0

    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public isCancelled()Z
    .locals 2

    .prologue
    .line 86
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    iget-object v1, p0, Lbolts/Task;->lock:Ljava/lang/Object;

    monitor-enter v1

    .line 87
    :try_start_0
    iget-boolean v0, p0, Lbolts/Task;->cancelled:Z

    monitor-exit v1

    return v0

    .line 88
    :catchall_0
    move-exception v0

    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public isCompleted()Z
    .locals 2

    .prologue
    .line 77
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    iget-object v1, p0, Lbolts/Task;->lock:Ljava/lang/Object;

    monitor-enter v1

    .line 78
    :try_start_0
    iget-boolean v0, p0, Lbolts/Task;->complete:Z

    monitor-exit v1

    return v0

    .line 79
    :catchall_0
    move-exception v0

    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public isFaulted()Z
    .locals 2

    .prologue
    .line 95
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    iget-object v1, p0, Lbolts/Task;->lock:Ljava/lang/Object;

    monitor-enter v1

    .line 96
    :try_start_0
    iget-object v0, p0, Lbolts/Task;->error:Ljava/lang/Exception;

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    monitor-exit v1

    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0

    .line 97
    :catchall_0
    move-exception v0

    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public makeVoid()Lbolts/Task;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lbolts/Task",
            "<",
            "Ljava/lang/Void;",
            ">;"
        }
    .end annotation

    .prologue
    .line 222
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    new-instance v0, Lbolts/Task$3;

    invoke-direct {v0, p0}, Lbolts/Task$3;-><init>(Lbolts/Task;)V

    invoke-virtual {p0, v0}, Lbolts/Task;->continueWithTask(Lbolts/Continuation;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public onSuccess(Lbolts/Continuation;)Lbolts/Task;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;TTContinuationResult;>;)",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 691
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;TTContinuationResult;>;"
    sget-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x0

    invoke-virtual {p0, p1, v0, v1}, Lbolts/Task;->onSuccess(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public onSuccess(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 1
    .param p2, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;TTContinuationResult;>;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 700
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;TTContinuationResult;>;"
    sget-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    invoke-virtual {p0, p1, v0, p2}, Lbolts/Task;->onSuccess(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public onSuccess(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;
    .locals 1
    .param p2, "executor"    # Ljava/util/concurrent/Executor;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;TTContinuationResult;>;",
            "Ljava/util/concurrent/Executor;",
            ")",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 657
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;TTContinuationResult;>;"
    const/4 v0, 0x0

    invoke-virtual {p0, p1, p2, v0}, Lbolts/Task;->onSuccess(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public onSuccess(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 1
    .param p2, "executor"    # Ljava/util/concurrent/Executor;
    .param p3, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;TTContinuationResult;>;",
            "Ljava/util/concurrent/Executor;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 667
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;TTContinuationResult;>;"
    new-instance v0, Lbolts/Task$12;

    invoke-direct {v0, p0, p3, p1}, Lbolts/Task$12;-><init>(Lbolts/Task;Lbolts/CancellationToken;Lbolts/Continuation;)V

    invoke-virtual {p0, v0, p2}, Lbolts/Task;->continueWithTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public onSuccessTask(Lbolts/Continuation;)Lbolts/Task;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;",
            "Lbolts/Task",
            "<TTContinuationResult;>;>;)",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 743
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;Lbolts/Task<TTContinuationResult;>;>;"
    sget-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    invoke-virtual {p0, p1, v0}, Lbolts/Task;->onSuccessTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public onSuccessTask(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 1
    .param p2, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;",
            "Lbolts/Task",
            "<TTContinuationResult;>;>;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 753
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;Lbolts/Task<TTContinuationResult;>;>;"
    sget-object v0, Lbolts/Task;->IMMEDIATE_EXECUTOR:Ljava/util/concurrent/Executor;

    invoke-virtual {p0, p1, v0, p2}, Lbolts/Task;->onSuccessTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public onSuccessTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;
    .locals 1
    .param p2, "executor"    # Ljava/util/concurrent/Executor;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;",
            "Lbolts/Task",
            "<TTContinuationResult;>;>;",
            "Ljava/util/concurrent/Executor;",
            ")",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 709
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;Lbolts/Task<TTContinuationResult;>;>;"
    const/4 v0, 0x0

    invoke-virtual {p0, p1, p2, v0}, Lbolts/Task;->onSuccessTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public onSuccessTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;
    .locals 1
    .param p2, "executor"    # Ljava/util/concurrent/Executor;
    .param p3, "ct"    # Lbolts/CancellationToken;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<TContinuationResult:",
            "Ljava/lang/Object;",
            ">(",
            "Lbolts/Continuation",
            "<TTResult;",
            "Lbolts/Task",
            "<TTContinuationResult;>;>;",
            "Ljava/util/concurrent/Executor;",
            "Lbolts/CancellationToken;",
            ")",
            "Lbolts/Task",
            "<TTContinuationResult;>;"
        }
    .end annotation

    .prologue
    .line 719
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    .local p1, "continuation":Lbolts/Continuation;, "Lbolts/Continuation<TTResult;Lbolts/Task<TTContinuationResult;>;>;"
    new-instance v0, Lbolts/Task$13;

    invoke-direct {v0, p0, p3, p1}, Lbolts/Task$13;-><init>(Lbolts/Task;Lbolts/CancellationToken;Lbolts/Continuation;)V

    invoke-virtual {p0, v0, p2}, Lbolts/Task;->continueWithTask(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;

    move-result-object v0

    return-object v0
.end method

.method public waitForCompletion()V
    .locals 2
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/InterruptedException;
        }
    .end annotation

    .prologue
    .line 122
    .local p0, "this":Lbolts/Task;, "Lbolts/Task<TTResult;>;"
    iget-object v1, p0, Lbolts/Task;->lock:Ljava/lang/Object;

    monitor-enter v1

    .line 123
    :try_start_0
    invoke-virtual {p0}, Lbolts/Task;->isCompleted()Z

    move-result v0

    if-nez v0, :cond_0

    .line 124
    iget-object v0, p0, Lbolts/Task;->lock:Ljava/lang/Object;

    invoke-virtual {v0}, Ljava/lang/Object;->wait()V

    .line 126
    :cond_0
    monitor-exit v1

    .line 127
    return-void

    .line 126
    :catchall_0
    move-exception v0

    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method
