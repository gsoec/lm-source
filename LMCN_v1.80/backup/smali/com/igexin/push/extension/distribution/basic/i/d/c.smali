.class abstract Lcom/igexin/push/extension/distribution/basic/i/d/c;
.super Lcom/igexin/push/extension/distribution/basic/i/d/g;


# instance fields
.field final a:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/d/g;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method constructor <init>()V
    .locals 1

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/g;-><init>()V

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/c;->a:Ljava/util/List;

    return-void
.end method

.method constructor <init>(Ljava/util/Collection;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Collection",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/d/g;",
            ">;)V"
        }
    .end annotation

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/c;-><init>()V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/c;->a:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->addAll(Ljava/util/Collection;)Z

    return-void
.end method


# virtual methods
.method a()Lcom/igexin/push/extension/distribution/basic/i/d/g;
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/c;->a:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    if-lez v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/c;->a:Ljava/util/List;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/c;->a:Ljava/util/List;

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v1

    add-int/lit8 v1, v1, -0x1

    invoke-interface {v0, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/d/g;

    :goto_0
    return-object v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method a(Lcom/igexin/push/extension/distribution/basic/i/d/g;)V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/c;->a:Ljava/util/List;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/c;->a:Ljava/util/List;

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v1

    add-int/lit8 v1, v1, -0x1

    invoke-interface {v0, v1, p1}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method
