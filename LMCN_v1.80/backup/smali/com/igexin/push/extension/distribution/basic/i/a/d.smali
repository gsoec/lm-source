.class Lcom/igexin/push/extension/distribution/basic/i/a/d;
.super Ljava/lang/Object;

# interfaces
.implements Ljava/util/Iterator;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "<E:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/lang/Object;",
        "Ljava/util/Iterator",
        "<TE;>;"
    }
.end annotation


# instance fields
.field final synthetic a:Lcom/igexin/push/extension/distribution/basic/i/a/b;

.field private final b:Ljava/util/ListIterator;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ListIterator",
            "<TE;>;"
        }
    .end annotation
.end field


# direct methods
.method private constructor <init>(Lcom/igexin/push/extension/distribution/basic/i/a/b;I)V
    .locals 1

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/a/d;->a:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    invoke-virtual {p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->listIterator(I)Ljava/util/ListIterator;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/d;->b:Ljava/util/ListIterator;

    return-void
.end method

.method synthetic constructor <init>(Lcom/igexin/push/extension/distribution/basic/i/a/b;ILcom/igexin/push/extension/distribution/basic/i/a/c;)V
    .locals 0

    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/a/d;-><init>(Lcom/igexin/push/extension/distribution/basic/i/a/b;I)V

    return-void
.end method


# virtual methods
.method public hasNext()Z
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/d;->b:Ljava/util/ListIterator;

    invoke-interface {v0}, Ljava/util/ListIterator;->hasPrevious()Z

    move-result v0

    return v0
.end method

.method public next()Ljava/lang/Object;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()TE;"
        }
    .end annotation

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/d;->b:Ljava/util/ListIterator;

    invoke-interface {v0}, Ljava/util/ListIterator;->previous()Ljava/lang/Object;

    move-result-object v0

    return-object v0
.end method

.method public remove()V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/d;->b:Ljava/util/ListIterator;

    invoke-interface {v0}, Ljava/util/ListIterator;->remove()V

    return-void
.end method
