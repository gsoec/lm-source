.class Lcom/igg/util/AsyncTask$AsyncTaskResult;
.super Ljava/lang/Object;
.source "AsyncTask.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/util/AsyncTask;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0xa
    name = "AsyncTaskResult"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "<Data:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/lang/Object;"
    }
.end annotation


# instance fields
.field final mData:[Ljava/lang/Object;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "[TData;"
        }
    .end annotation
.end field

.field final mTask:Lcom/igg/util/AsyncTask;


# direct methods
.method varargs constructor <init>(Lcom/igg/util/AsyncTask;[Ljava/lang/Object;)V
    .locals 0
    .param p1, "task"    # Lcom/igg/util/AsyncTask;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/util/AsyncTask;",
            "[TData;)V"
        }
    .end annotation

    .prologue
    .line 688
    .local p0, "this":Lcom/igg/util/AsyncTask$AsyncTaskResult;, "Lcom/igg/util/AsyncTask$AsyncTaskResult<TData;>;"
    .local p2, "data":[Ljava/lang/Object;, "[TData;"
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 689
    iput-object p1, p0, Lcom/igg/util/AsyncTask$AsyncTaskResult;->mTask:Lcom/igg/util/AsyncTask;

    .line 690
    iput-object p2, p0, Lcom/igg/util/AsyncTask$AsyncTaskResult;->mData:[Ljava/lang/Object;

    .line 691
    return-void
.end method
