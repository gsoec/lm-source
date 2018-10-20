.class public Lcom/igexin/push/extension/distribution/basic/i/a/b;
.super Ljava/util/LinkedList;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "<E:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/util/LinkedList",
        "<TE;>;"
    }
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    invoke-direct {p0}, Ljava/util/LinkedList;-><init>()V

    return-void
.end method


# virtual methods
.method public descendingIterator()Ljava/util/Iterator;
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Iterator",
            "<TE;>;"
        }
    .end annotation

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/a/d;

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->size()I

    move-result v1

    const/4 v2, 0x0

    invoke-direct {v0, p0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/a/d;-><init>(Lcom/igexin/push/extension/distribution/basic/i/a/b;ILcom/igexin/push/extension/distribution/basic/i/a/c;)V

    return-object v0
.end method

.method public peekLast()Ljava/lang/Object;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()TE;"
        }
    .end annotation

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->size()I

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x0

    :goto_0
    return-object v0

    :cond_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->getLast()Ljava/lang/Object;

    move-result-object v0

    goto :goto_0
.end method

.method public pollLast()Ljava/lang/Object;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()TE;"
        }
    .end annotation

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->size()I

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x0

    :goto_0
    return-object v0

    :cond_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->removeLast()Ljava/lang/Object;

    move-result-object v0

    goto :goto_0
.end method

.method public push(Ljava/lang/Object;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(TE;)V"
        }
    .end annotation

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->addFirst(Ljava/lang/Object;)V

    return-void
.end method
