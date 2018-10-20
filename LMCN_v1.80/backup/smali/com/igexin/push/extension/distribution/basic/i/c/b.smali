.class Lcom/igexin/push/extension/distribution/basic/i/c/b;
.super Lcom/igexin/push/extension/distribution/basic/i/c/dh;


# static fields
.field static final synthetic a:Z


# instance fields
.field private i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

.field private j:Lcom/igexin/push/extension/distribution/basic/i/c/c;

.field private k:Z

.field private l:Lcom/igexin/push/extension/distribution/basic/i/b/i;

.field private m:Lcom/igexin/push/extension/distribution/basic/i/b/i;

.field private n:Lcom/igexin/push/extension/distribution/basic/i/b/i;

.field private o:Lcom/igexin/push/extension/distribution/basic/i/a/b;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/igexin/push/extension/distribution/basic/i/a/b",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/b/i;",
            ">;"
        }
    .end annotation
.end field

.field private p:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/c/ah;",
            ">;"
        }
    .end annotation
.end field

.field private q:Z

.field private r:Z

.field private s:Z


# direct methods
.method static constructor <clinit>()V
    .locals 1

    const-class v0, Lcom/igexin/push/extension/distribution/basic/i/c/b;

    invoke-virtual {v0}, Ljava/lang/Class;->desiredAssertionStatus()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    sput-boolean v0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a:Z

    return-void

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method constructor <init>()V
    .locals 2

    const/4 v1, 0x0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/dh;-><init>()V

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->k:Z

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->p:Ljava/util/List;

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->q:Z

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->r:Z

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->s:Z

    return-void
.end method

.method private a(Ljava/util/LinkedList;Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)V
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/LinkedList",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/b/i;",
            ">;",
            "Lcom/igexin/push/extension/distribution/basic/i/b/i;",
            "Lcom/igexin/push/extension/distribution/basic/i/b/i;",
            ")V"
        }
    .end annotation

    invoke-virtual {p1, p2}, Ljava/util/LinkedList;->lastIndexOf(Ljava/lang/Object;)I

    move-result v1

    const/4 v0, -0x1

    if-eq v1, v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Z)V

    invoke-virtual {p1, v1}, Ljava/util/LinkedList;->remove(I)Ljava/lang/Object;

    invoke-virtual {p1, v1, p3}, Ljava/util/LinkedList;->add(ILjava/lang/Object;)V

    return-void

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private a(Lcom/igexin/push/extension/distribution/basic/i/a/b;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igexin/push/extension/distribution/basic/i/a/b",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/b/i;",
            ">;",
            "Lcom/igexin/push/extension/distribution/basic/i/b/i;",
            ")Z"
        }
    .end annotation

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-ne v0, p2, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_1
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private a(Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;)Z
    .locals 2

    const/4 v0, 0x1

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    aput-object p1, v0, v1

    invoke-direct {p0, v0, p2, p3}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a([Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method private a([Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;)Z
    .locals 4

    const/4 v1, 0x0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v2

    :cond_0
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_3

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_1

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_1
    invoke-static {v0, p2}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_2

    move v0, v1

    goto :goto_0

    :cond_2
    if-eqz p3, :cond_0

    invoke-static {v0, p3}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    move v0, v1

    goto :goto_0

    :cond_3
    const-string v0, "Should not be reachable"

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->b(Ljava/lang/String;)V

    move v0, v1

    goto :goto_0
.end method

.method private b(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->size()I

    move-result v0

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->d:Lcom/igexin/push/extension/distribution/basic/i/b/e;

    invoke-virtual {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    :goto_0
    return-void

    :cond_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    goto :goto_0

    :cond_1
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto :goto_0
.end method

.method private varargs c([Ljava/lang/String;)V
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, p1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v2, "html"

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    :cond_0
    return-void

    :cond_1
    invoke-interface {v1}, Ljava/util/Iterator;->remove()V

    goto :goto_0
.end method

.method private d(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z
    .locals 2

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->x()Lcom/igexin/push/extension/distribution/basic/i/b/b;

    move-result-object v0

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->x()Lcom/igexin/push/extension/distribution/basic/i/b/b;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method


# virtual methods
.method a(Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/c/ac;)Lcom/igexin/push/extension/distribution/basic/i/b/e;
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-super {p0, p1, p2, p3}, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->a(Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/c/ac;)Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v0

    return-object v0
.end method

.method a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 4

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->p()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->o()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->b(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_0

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->h()Ljava/lang/String;

    move-result-object v2

    invoke-direct {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :goto_0
    return-object v0

    :cond_0
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->o()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    move-result-object v1

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f:Ljava/lang/String;

    iget-object v3, p1, Lcom/igexin/push/extension/distribution/basic/i/c/am;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-direct {v0, v1, v2, v3}, Lcom/igexin/push/extension/distribution/basic/i/b/i;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/ae;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/b;)V

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    goto :goto_0
.end method

.method a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 3

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    move-result-object v1

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f:Ljava/lang/String;

    invoke-direct {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/i;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/ae;Ljava/lang/String;)V

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    return-object v0
.end method

.method a()Lcom/igexin/push/extension/distribution/basic/i/c/c;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    return-object v0
.end method

.method a(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V
    .locals 2

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->k:Z

    if-eqz v0, :cond_1

    :cond_0
    :goto_0
    return-void

    :cond_1
    const-string v0, "href"

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->g(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v1

    if-eqz v1, :cond_0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f:Ljava/lang/String;

    const/4 v1, 0x1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->k:Z

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->d:Lcom/igexin/push/extension/distribution/basic/i/b/e;

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->f(Ljava/lang/String;)V

    goto :goto_0
.end method

.method a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->lastIndexOf(Ljava/lang/Object;)I

    move-result v1

    const/4 v0, -0x1

    if-eq v1, v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Z)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    add-int/lit8 v1, v1, 0x1

    invoke-virtual {v0, v1, p2}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->add(ILjava/lang/Object;)V

    return-void

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V
    .locals 4

    const/4 v1, 0x0

    const-string v0, "table"

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v2

    if-eqz v2, :cond_1

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v1

    const/4 v0, 0x1

    :goto_0
    if-eqz v0, :cond_2

    invoke-static {v2}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    invoke-virtual {v2, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->b(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    :goto_1
    return-void

    :cond_0
    invoke-virtual {p0, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    move v3, v1

    move-object v1, v0

    move v0, v3

    goto :goto_0

    :cond_1
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move v3, v1

    move-object v1, v0

    move v0, v3

    goto :goto_0

    :cond_2
    invoke-virtual {v1, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto :goto_1
.end method

.method a(Lcom/igexin/push/extension/distribution/basic/i/c/ah;)V
    .locals 4

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->h()Ljava/lang/String;

    move-result-object v0

    const/4 v1, 0x2

    new-array v1, v1, [Ljava/lang/String;

    const/4 v2, 0x0

    const-string v3, "script"

    aput-object v3, v1, v2

    const/4 v2, 0x1

    const-string v3, "style"

    aput-object v3, v1, v2

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/d;

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/ah;->m()Ljava/lang/String;

    move-result-object v1

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f:Ljava/lang/String;

    invoke-direct {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/d;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    :goto_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v1

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    return-void

    :cond_0
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/o;

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/ah;->m()Ljava/lang/String;

    move-result-object v1

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f:Ljava/lang/String;

    invoke-direct {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/o;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method

.method a(Lcom/igexin/push/extension/distribution/basic/i/c/ai;)V
    .locals 3

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/c;

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/ai;->m()Ljava/lang/String;

    move-result-object v1

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f:Ljava/lang/String;

    invoke-direct {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/c;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    return-void
.end method

.method a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    return-void
.end method

.method a(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->q:Z

    return-void
.end method

.method varargs a([Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->remove()V

    :cond_0
    return-void

    :cond_1
    invoke-interface {v1}, Ljava/util/Iterator;->remove()V

    goto :goto_0
.end method

.method protected a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z
    .locals 1

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g:Lcom/igexin/push/extension/distribution/basic/i/c/af;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {v0, p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    return v0
.end method

.method a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z
    .locals 1

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g:Lcom/igexin/push/extension/distribution/basic/i/c/af;

    invoke-virtual {p2, p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    return v0
.end method

.method a(Ljava/lang/String;[Ljava/lang/String;)Z
    .locals 3

    const/16 v0, 0x8

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "applet"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "caption"

    aput-object v2, v0, v1

    const/4 v1, 0x2

    const-string v2, "html"

    aput-object v2, v0, v1

    const/4 v1, 0x3

    const-string v2, "table"

    aput-object v2, v0, v1

    const/4 v1, 0x4

    const-string v2, "td"

    aput-object v2, v0, v1

    const/4 v1, 0x5

    const-string v2, "th"

    aput-object v2, v0, v1

    const/4 v1, 0x6

    const-string v2, "marquee"

    aput-object v2, v0, v1

    const/4 v1, 0x7

    const-string v2, "object"

    aput-object v2, v0, v1

    invoke-direct {p0, p1, v0, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method b(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 4

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->o()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f:Ljava/lang/String;

    iget-object v3, p1, Lcom/igexin/push/extension/distribution/basic/i/c/am;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-direct {v1, v0, v2, v3}, Lcom/igexin/push/extension/distribution/basic/i/b/i;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/ae;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/b;)V

    invoke-direct {p0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->p()Z

    move-result v2

    if-eqz v2, :cond_0

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aq;

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b()V

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->e()Z

    move-result v2

    if-nez v2, :cond_0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->g()Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    :cond_0
    return-object v1
.end method

.method b(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v2, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    :goto_0
    return-object v0

    :cond_1
    const/4 v0, 0x0

    goto :goto_0
.end method

.method b()V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    return-void
.end method

.method b(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V
    .locals 1

    invoke-direct {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method b(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-direct {p0, v0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Ljava/util/LinkedList;Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    return-void
.end method

.method b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V
    .locals 7

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->a()Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/c/ab;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->a()I

    move-result v2

    const-string v3, "Unexpected token [%s] when in state [%s]"

    const/4 v4, 0x2

    new-array v4, v4, [Ljava/lang/Object;

    const/4 v5, 0x0

    iget-object v6, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g:Lcom/igexin/push/extension/distribution/basic/i/c/af;

    invoke-virtual {v6}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->a()Ljava/lang/String;

    move-result-object v6

    aput-object v6, v4, v5

    const/4 v5, 0x1

    aput-object p1, v4, v5

    invoke-direct {v1, v2, v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/c/ab;-><init>(ILjava/lang/String;[Ljava/lang/Object;)V

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->add(Ljava/lang/Object;)Z

    :cond_0
    return-void
.end method

.method b(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->r:Z

    return-void
.end method

.method b([Ljava/lang/String;)Z
    .locals 3

    const/16 v0, 0x8

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "applet"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "caption"

    aput-object v2, v0, v1

    const/4 v1, 0x2

    const-string v2, "html"

    aput-object v2, v0, v1

    const/4 v1, 0x3

    const-string v2, "table"

    aput-object v2, v0, v1

    const/4 v1, 0x4

    const-string v2, "td"

    aput-object v2, v0, v1

    const/4 v1, 0x5

    const-string v2, "th"

    aput-object v2, v0, v1

    const/4 v1, 0x6

    const-string v2, "marquee"

    aput-object v2, v0, v1

    const/4 v1, 0x7

    const-string v2, "object"

    aput-object v2, v0, v1

    const/4 v1, 0x0

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a([Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method c()Lcom/igexin/push/extension/distribution/basic/i/c/c;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    return-object v0
.end method

.method c(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method c(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-direct {p0, v0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Ljava/util/LinkedList;Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    return-void
.end method

.method c(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->remove()V

    :cond_0
    return-void

    :cond_1
    invoke-interface {v1}, Ljava/util/Iterator;->remove()V

    goto :goto_0
.end method

.method d(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    :cond_0
    return-void

    :cond_1
    invoke-interface {v1}, Ljava/util/Iterator;->remove()V

    goto :goto_0
.end method

.method d()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->q:Z

    return v0
.end method

.method d(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-direct {p0, v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/a/b;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v0

    return v0
.end method

.method e()Lcom/igexin/push/extension/distribution/basic/i/b/e;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->d:Lcom/igexin/push/extension/distribution/basic/i/b/e;

    return-object v0
.end method

.method e(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-ne v0, p1, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->remove()V

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_1
    const/4 v0, 0x0

    goto :goto_0
.end method

.method e(Ljava/lang/String;)Z
    .locals 1

    const/4 v0, 0x0

    invoke-virtual {p0, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method f(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 2

    sget-boolean v0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a:Z

    if-nez v0, :cond_0

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->d(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v0

    if-nez v0, :cond_0

    new-instance v0, Ljava/lang/AssertionError;

    invoke-direct {v0}, Ljava/lang/AssertionError;-><init>()V

    throw v0

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_1
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_2

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-ne v0, p1, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    :goto_0
    return-object v0

    :cond_2
    const/4 v0, 0x0

    goto :goto_0
.end method

.method f()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f:Ljava/lang/String;

    return-object v0
.end method

.method f(Ljava/lang/String;)Z
    .locals 3

    const/4 v0, 0x2

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "ol"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "ul"

    aput-object v2, v0, v1

    invoke-virtual {p0, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method g(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->l:Lcom/igexin/push/extension/distribution/basic/i/b/i;

    return-void
.end method

.method g()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->s:Z

    return v0
.end method

.method g(Ljava/lang/String;)Z
    .locals 3

    const/4 v0, 0x1

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "button"

    aput-object v2, v0, v1

    invoke-virtual {p0, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method h()Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 3

    const/4 v2, 0x1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->peekLast()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v1, "td"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->name()Ljava/lang/String;

    move-result-object v0

    const-string v1, "InCell"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    const-string v0, "pop td not in cell"

    invoke-static {v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->b(ZLjava/lang/String;)V

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->peekLast()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v1, "html"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    const-string v0, "popping html!"

    invoke-static {v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->b(ZLjava/lang/String;)V

    :cond_1
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->pollLast()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    return-object v0
.end method

.method h(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->m:Lcom/igexin/push/extension/distribution/basic/i/b/i;

    return-void
.end method

.method h(Ljava/lang/String;)Z
    .locals 3

    const/4 v0, 0x2

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "html"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "table"

    aput-object v2, v0, v1

    const/4 v1, 0x0

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method i()Lcom/igexin/push/extension/distribution/basic/i/a/b;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/igexin/push/extension/distribution/basic/i/a/b",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/b/i;",
            ">;"
        }
    .end annotation

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    return-object v0
.end method

.method i(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z
    .locals 4

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const/16 v1, 0x4f

    new-array v1, v1, [Ljava/lang/String;

    const/4 v2, 0x0

    const-string v3, "address"

    aput-object v3, v1, v2

    const/4 v2, 0x1

    const-string v3, "applet"

    aput-object v3, v1, v2

    const/4 v2, 0x2

    const-string v3, "area"

    aput-object v3, v1, v2

    const/4 v2, 0x3

    const-string v3, "article"

    aput-object v3, v1, v2

    const/4 v2, 0x4

    const-string v3, "aside"

    aput-object v3, v1, v2

    const/4 v2, 0x5

    const-string v3, "base"

    aput-object v3, v1, v2

    const/4 v2, 0x6

    const-string v3, "basefont"

    aput-object v3, v1, v2

    const/4 v2, 0x7

    const-string v3, "bgsound"

    aput-object v3, v1, v2

    const/16 v2, 0x8

    const-string v3, "blockquote"

    aput-object v3, v1, v2

    const/16 v2, 0x9

    const-string v3, "body"

    aput-object v3, v1, v2

    const/16 v2, 0xa

    const-string v3, "br"

    aput-object v3, v1, v2

    const/16 v2, 0xb

    const-string v3, "button"

    aput-object v3, v1, v2

    const/16 v2, 0xc

    const-string v3, "caption"

    aput-object v3, v1, v2

    const/16 v2, 0xd

    const-string v3, "center"

    aput-object v3, v1, v2

    const/16 v2, 0xe

    const-string v3, "col"

    aput-object v3, v1, v2

    const/16 v2, 0xf

    const-string v3, "colgroup"

    aput-object v3, v1, v2

    const/16 v2, 0x10

    const-string v3, "command"

    aput-object v3, v1, v2

    const/16 v2, 0x11

    const-string v3, "dd"

    aput-object v3, v1, v2

    const/16 v2, 0x12

    const-string v3, "details"

    aput-object v3, v1, v2

    const/16 v2, 0x13

    const-string v3, "dir"

    aput-object v3, v1, v2

    const/16 v2, 0x14

    const-string v3, "div"

    aput-object v3, v1, v2

    const/16 v2, 0x15

    const-string v3, "dl"

    aput-object v3, v1, v2

    const/16 v2, 0x16

    const-string v3, "dt"

    aput-object v3, v1, v2

    const/16 v2, 0x17

    const-string v3, "embed"

    aput-object v3, v1, v2

    const/16 v2, 0x18

    const-string v3, "fieldset"

    aput-object v3, v1, v2

    const/16 v2, 0x19

    const-string v3, "figcaption"

    aput-object v3, v1, v2

    const/16 v2, 0x1a

    const-string v3, "figure"

    aput-object v3, v1, v2

    const/16 v2, 0x1b

    const-string v3, "footer"

    aput-object v3, v1, v2

    const/16 v2, 0x1c

    const-string v3, "form"

    aput-object v3, v1, v2

    const/16 v2, 0x1d

    const-string v3, "frame"

    aput-object v3, v1, v2

    const/16 v2, 0x1e

    const-string v3, "frameset"

    aput-object v3, v1, v2

    const/16 v2, 0x1f

    const-string v3, "h1"

    aput-object v3, v1, v2

    const/16 v2, 0x20

    const-string v3, "h2"

    aput-object v3, v1, v2

    const/16 v2, 0x21

    const-string v3, "h3"

    aput-object v3, v1, v2

    const/16 v2, 0x22

    const-string v3, "h4"

    aput-object v3, v1, v2

    const/16 v2, 0x23

    const-string v3, "h5"

    aput-object v3, v1, v2

    const/16 v2, 0x24

    const-string v3, "h6"

    aput-object v3, v1, v2

    const/16 v2, 0x25

    const-string v3, "head"

    aput-object v3, v1, v2

    const/16 v2, 0x26

    const-string v3, "header"

    aput-object v3, v1, v2

    const/16 v2, 0x27

    const-string v3, "hgroup"

    aput-object v3, v1, v2

    const/16 v2, 0x28

    const-string v3, "hr"

    aput-object v3, v1, v2

    const/16 v2, 0x29

    const-string v3, "html"

    aput-object v3, v1, v2

    const/16 v2, 0x2a

    const-string v3, "iframe"

    aput-object v3, v1, v2

    const/16 v2, 0x2b

    const-string v3, "img"

    aput-object v3, v1, v2

    const/16 v2, 0x2c

    const-string v3, "input"

    aput-object v3, v1, v2

    const/16 v2, 0x2d

    const-string v3, "isindex"

    aput-object v3, v1, v2

    const/16 v2, 0x2e

    const-string v3, "li"

    aput-object v3, v1, v2

    const/16 v2, 0x2f

    const-string v3, "link"

    aput-object v3, v1, v2

    const/16 v2, 0x30

    const-string v3, "listing"

    aput-object v3, v1, v2

    const/16 v2, 0x31

    const-string v3, "marquee"

    aput-object v3, v1, v2

    const/16 v2, 0x32

    const-string v3, "menu"

    aput-object v3, v1, v2

    const/16 v2, 0x33

    const-string v3, "meta"

    aput-object v3, v1, v2

    const/16 v2, 0x34

    const-string v3, "nav"

    aput-object v3, v1, v2

    const/16 v2, 0x35

    const-string v3, "noembed"

    aput-object v3, v1, v2

    const/16 v2, 0x36

    const-string v3, "noframes"

    aput-object v3, v1, v2

    const/16 v2, 0x37

    const-string v3, "noscript"

    aput-object v3, v1, v2

    const/16 v2, 0x38

    const-string v3, "object"

    aput-object v3, v1, v2

    const/16 v2, 0x39

    const-string v3, "ol"

    aput-object v3, v1, v2

    const/16 v2, 0x3a

    const-string v3, "p"

    aput-object v3, v1, v2

    const/16 v2, 0x3b

    const-string v3, "param"

    aput-object v3, v1, v2

    const/16 v2, 0x3c

    const-string v3, "plaintext"

    aput-object v3, v1, v2

    const/16 v2, 0x3d

    const-string v3, "pre"

    aput-object v3, v1, v2

    const/16 v2, 0x3e

    const-string v3, "script"

    aput-object v3, v1, v2

    const/16 v2, 0x3f

    const-string v3, "section"

    aput-object v3, v1, v2

    const/16 v2, 0x40

    const-string v3, "select"

    aput-object v3, v1, v2

    const/16 v2, 0x41

    const-string v3, "style"

    aput-object v3, v1, v2

    const/16 v2, 0x42

    const-string v3, "summary"

    aput-object v3, v1, v2

    const/16 v2, 0x43

    const-string v3, "table"

    aput-object v3, v1, v2

    const/16 v2, 0x44

    const-string v3, "tbody"

    aput-object v3, v1, v2

    const/16 v2, 0x45

    const-string v3, "td"

    aput-object v3, v1, v2

    const/16 v2, 0x46

    const-string v3, "textarea"

    aput-object v3, v1, v2

    const/16 v2, 0x47

    const-string v3, "tfoot"

    aput-object v3, v1, v2

    const/16 v2, 0x48

    const-string v3, "th"

    aput-object v3, v1, v2

    const/16 v2, 0x49

    const-string v3, "thead"

    aput-object v3, v1, v2

    const/16 v2, 0x4a

    const-string v3, "title"

    aput-object v3, v1, v2

    const/16 v2, 0x4b

    const-string v3, "tr"

    aput-object v3, v1, v2

    const/16 v2, 0x4c

    const-string v3, "ul"

    aput-object v3, v1, v2

    const/16 v2, 0x4d

    const-string v3, "wbr"

    aput-object v3, v1, v2

    const/16 v2, 0x4e

    const-string v3, "xmp"

    aput-object v3, v1, v2

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method i(Ljava/lang/String;)Z
    .locals 6

    const/4 v1, 0x1

    const/4 v2, 0x0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v3

    :cond_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_2

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1

    move v0, v1

    :goto_0
    return v0

    :cond_1
    const/4 v4, 0x2

    new-array v4, v4, [Ljava/lang/String;

    const-string v5, "optgroup"

    aput-object v5, v4, v2

    const-string v5, "option"

    aput-object v5, v4, v1

    invoke-static {v0, v4}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_0

    move v0, v2

    goto :goto_0

    :cond_2
    const-string v0, "Should not be reachable"

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->b(Ljava/lang/String;)V

    move v0, v2

    goto :goto_0
.end method

.method j()V
    .locals 3

    const/4 v0, 0x1

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "table"

    aput-object v2, v0, v1

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c([Ljava/lang/String;)V

    return-void
.end method

.method j(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V
    .locals 3

    const/4 v0, 0x0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v2

    move v1, v0

    :goto_0
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-nez v0, :cond_1

    :cond_0
    :goto_1
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->add(Ljava/lang/Object;)Z

    return-void

    :cond_1
    invoke-direct {p0, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->d(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v0

    if-eqz v0, :cond_3

    add-int/lit8 v0, v1, 0x1

    :goto_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_2

    invoke-interface {v2}, Ljava/util/Iterator;->remove()V

    goto :goto_1

    :cond_2
    move v1, v0

    goto :goto_0

    :cond_3
    move v0, v1

    goto :goto_2
.end method

.method j(Ljava/lang/String;)V
    .locals 4

    :goto_0
    if-eqz p1, :cond_0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const/16 v1, 0x8

    new-array v1, v1, [Ljava/lang/String;

    const/4 v2, 0x0

    const-string v3, "dd"

    aput-object v3, v1, v2

    const/4 v2, 0x1

    const-string v3, "dt"

    aput-object v3, v1, v2

    const/4 v2, 0x2

    const-string v3, "li"

    aput-object v3, v1, v2

    const/4 v2, 0x3

    const-string v3, "option"

    aput-object v3, v1, v2

    const/4 v2, 0x4

    const-string v3, "optgroup"

    aput-object v3, v1, v2

    const/4 v2, 0x5

    const-string v3, "p"

    aput-object v3, v1, v2

    const/4 v2, 0x6

    const-string v3, "rp"

    aput-object v3, v1, v2

    const/4 v2, 0x7

    const-string v3, "rt"

    aput-object v3, v1, v2

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto :goto_0

    :cond_0
    return-void
.end method

.method k(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-nez v0, :cond_2

    :cond_1
    const/4 v0, 0x0

    :goto_0
    return-object v0

    :cond_2
    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v2, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    goto :goto_0
.end method

.method k()V
    .locals 3

    const/4 v0, 0x3

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "tbody"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "tfoot"

    aput-object v2, v0, v1

    const/4 v1, 0x2

    const-string v2, "thead"

    aput-object v2, v0, v1

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c([Ljava/lang/String;)V

    return-void
.end method

.method k(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-ne v0, p1, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->remove()V

    :cond_1
    return-void
.end method

.method l()V
    .locals 3

    const/4 v0, 0x1

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "tr"

    aput-object v2, v0, v1

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c([Ljava/lang/String;)V

    return-void
.end method

.method l(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-direct {p0, v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/a/b;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v0

    return v0
.end method

.method m()V
    .locals 5

    const/4 v0, 0x0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v2

    move v1, v0

    :goto_0
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-nez v3, :cond_f

    const/4 v1, 0x1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->n:Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-object v4, v0

    move v0, v1

    move-object v1, v4

    :goto_1
    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v1

    const-string v3, "select"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_1

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->p:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    :cond_0
    :goto_2
    return-void

    :cond_1
    const-string v3, "td"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_2

    const-string v3, "td"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_3

    if-nez v0, :cond_3

    :cond_2
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->o:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_2

    :cond_3
    const-string v3, "tr"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_4

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->n:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_2

    :cond_4
    const-string v3, "tbody"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_5

    const-string v3, "thead"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_5

    const-string v3, "tfoot"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_6

    :cond_5
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->m:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_2

    :cond_6
    const-string v3, "caption"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_7

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->k:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_2

    :cond_7
    const-string v3, "colgroup"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_8

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->l:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_2

    :cond_8
    const-string v3, "table"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_9

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_2

    :cond_9
    const-string v3, "head"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_a

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->g:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_2

    :cond_a
    const-string v3, "body"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_b

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->g:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_2

    :cond_b
    const-string v3, "frameset"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_c

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->s:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_2

    :cond_c
    const-string v3, "html"

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_d

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->c:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_2

    :cond_d
    if-eqz v0, :cond_e

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/c;->g:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_2

    :cond_e
    move v1, v0

    goto/16 :goto_0

    :cond_f
    move-object v4, v0

    move v0, v1

    move-object v1, v4

    goto/16 :goto_1
.end method

.method n()Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->l:Lcom/igexin/push/extension/distribution/basic/i/b/i;

    return-object v0
.end method

.method o()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->r:Z

    return v0
.end method

.method p()Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->m:Lcom/igexin/push/extension/distribution/basic/i/b/i;

    return-object v0
.end method

.method q()V
    .locals 1

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->p:Ljava/util/List;

    return-void
.end method

.method r()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/c/ah;",
            ">;"
        }
    .end annotation

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->p:Ljava/util/List;

    return-object v0
.end method

.method s()V
    .locals 1

    const/4 v0, 0x0

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j(Ljava/lang/String;)V

    return-void
.end method

.method t()V
    .locals 8

    const/4 v3, 0x0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->size()I

    move-result v4

    if-eqz v4, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->getLast()Ljava/lang/Object;

    move-result-object v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->getLast()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->d(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v0

    if-eqz v0, :cond_1

    :cond_0
    return-void

    :cond_1
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->getLast()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    add-int/lit8 v1, v4, -0x1

    move-object v2, v0

    :goto_0
    if-nez v1, :cond_3

    const/4 v0, 0x1

    move v7, v0

    move v0, v1

    move-object v1, v2

    move v2, v7

    :goto_1
    if-nez v2, :cond_2

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    add-int/lit8 v1, v0, 0x1

    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move v7, v1

    move-object v1, v0

    move v0, v7

    :cond_2
    invoke-static {v1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p0, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->x()Lcom/igexin/push/extension/distribution/basic/i/b/b;

    move-result-object v5

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->x()Lcom/igexin/push/extension/distribution/basic/i/b/b;

    move-result-object v6

    invoke-virtual {v5, v6}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Lcom/igexin/push/extension/distribution/basic/i/b/b;)V

    iget-object v5, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v5, v0, v2}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->add(ILjava/lang/Object;)V

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    add-int/lit8 v5, v0, 0x1

    invoke-virtual {v2, v5}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->remove(I)Ljava/lang/Object;

    add-int/lit8 v2, v4, -0x1

    if-eq v0, v2, :cond_0

    move v2, v3

    goto :goto_1

    :cond_3
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    add-int/lit8 v1, v1, -0x1

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-eqz v0, :cond_5

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->d(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v2

    if-eqz v2, :cond_4

    move v2, v3

    move v7, v1

    move-object v1, v0

    move v0, v7

    goto :goto_1

    :cond_4
    move-object v2, v0

    goto :goto_0

    :cond_5
    move v2, v3

    move v7, v1

    move-object v1, v0

    move v0, v7

    goto :goto_1
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "TreeBuilder{currentToken="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g:Lcom/igexin/push/extension/distribution/basic/i/c/af;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ", state="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ", currentElement="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const/16 v1, 0x7d

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method u()V
    .locals 2

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->peekLast()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->removeLast()Ljava/lang/Object;

    if-nez v0, :cond_0

    :cond_1
    return-void
.end method

.method v()V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/b;->o:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->add(Ljava/lang/Object;)Z

    return-void
.end method
