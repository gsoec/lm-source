.class public Lcom/igexin/push/extension/distribution/gbd/i/q;
.super Ljava/lang/Object;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "<E:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/lang/Object;"
    }
.end annotation


# instance fields
.field private a:Ljava/util/Comparator;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Comparator",
            "<TE;>;"
        }
    .end annotation
.end field

.field private b:I


# direct methods
.method public constructor <init>(Ljava/util/Comparator;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Comparator",
            "<TE;>;)V"
        }
    .end annotation

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/gbd/i/q;->a(Ljava/util/Comparator;)V

    return-void
.end method

.method private a(Ljava/util/List;IILjava/lang/Object;)Z
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<TE;>;IITE;)Z"
        }
    .end annotation

    const/4 v2, 0x0

    move v0, p3

    move v1, p2

    :goto_0
    if-gt v1, v0, :cond_2

    add-int v3, v1, v0

    shr-int/lit8 v3, v3, 0x1

    invoke-interface {p1, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    iget-object v5, p0, Lcom/igexin/push/extension/distribution/gbd/i/q;->a:Ljava/util/Comparator;

    invoke-interface {v5, v4, p4}, Ljava/util/Comparator;->compare(Ljava/lang/Object;Ljava/lang/Object;)I

    move-result v4

    if-nez v4, :cond_0

    const/4 v0, 0x1

    move v1, v3

    :goto_1
    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/i/q;->b:I

    return v0

    :cond_0
    if-gez v4, :cond_1

    add-int/lit8 v1, v3, 0x1

    goto :goto_0

    :cond_1
    add-int/lit8 v0, v3, -0x1

    goto :goto_0

    :cond_2
    move v0, v2

    goto :goto_1
.end method


# virtual methods
.method public a(Ljava/util/List;Ljava/util/List;)Ljava/util/List;
    .locals 11
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<TE;>;",
            "Ljava/util/List",
            "<TE;>;)",
            "Ljava/util/List",
            "<TE;>;"
        }
    .end annotation

    const/4 v0, 0x0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/i/q;->a:Ljava/util/Comparator;

    if-eqz v1, :cond_0

    if-eqz p1, :cond_0

    invoke-interface {p1}, Ljava/util/List;->isEmpty()Z

    move-result v1

    if-nez v1, :cond_0

    if-eqz p2, :cond_0

    invoke-interface {p2}, Ljava/util/List;->isEmpty()Z

    move-result v1

    if-eqz v1, :cond_1

    :cond_0
    const/4 v0, 0x0

    :goto_0
    return-object v0

    :cond_1
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v4

    invoke-interface {p2}, Ljava/util/List;->size()I

    move-result v5

    add-int/lit8 v6, v4, -0x1

    add-int/lit8 v7, v5, -0x1

    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    move v3, v0

    move v1, v0

    :goto_1
    if-ge v1, v4, :cond_6

    if-ge v3, v5, :cond_6

    invoke-interface {p1, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    invoke-interface {p2, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v8

    iget-object v9, p0, Lcom/igexin/push/extension/distribution/gbd/i/q;->a:Ljava/util/Comparator;

    invoke-interface {v9, v0, v8}, Ljava/util/Comparator;->compare(Ljava/lang/Object;Ljava/lang/Object;)I

    move-result v9

    if-nez v9, :cond_2

    invoke-interface {v2, v0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    add-int/lit8 v1, v1, 0x1

    add-int/lit8 v0, v3, 0x1

    :goto_2
    move v3, v0

    goto :goto_1

    :cond_2
    if-gez v9, :cond_4

    add-int/lit8 v0, v1, 0x1

    invoke-direct {p0, p1, v0, v6, v8}, Lcom/igexin/push/extension/distribution/gbd/i/q;->a(Ljava/util/List;IILjava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_3

    invoke-interface {v2, v8}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/i/q;->b:I

    add-int/lit8 v0, v0, 0x1

    :goto_3
    add-int/lit8 v1, v3, 0x1

    move v10, v1

    move v1, v0

    move v0, v10

    goto :goto_2

    :cond_3
    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/i/q;->b:I

    goto :goto_3

    :cond_4
    add-int/lit8 v3, v3, 0x1

    invoke-direct {p0, p2, v3, v7, v0}, Lcom/igexin/push/extension/distribution/gbd/i/q;->a(Ljava/util/List;IILjava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_5

    invoke-interface {v2, v0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/i/q;->b:I

    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    goto :goto_2

    :cond_5
    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/i/q;->b:I

    add-int/lit8 v1, v1, 0x1

    goto :goto_2

    :cond_6
    move-object v0, v2

    goto :goto_0
.end method

.method public a(Ljava/util/Comparator;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Comparator",
            "<TE;>;)V"
        }
    .end annotation

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/gbd/i/q;->a:Ljava/util/Comparator;

    return-void
.end method
