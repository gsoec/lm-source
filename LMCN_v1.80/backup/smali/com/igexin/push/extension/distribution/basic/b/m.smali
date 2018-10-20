.class public Lcom/igexin/push/extension/distribution/basic/b/m;
.super Lcom/igexin/push/core/bean/BaseAction;


# instance fields
.field private A:Z

.field private B:I

.field private C:I

.field private D:I

.field private E:I

.field private F:Lcom/igexin/push/extension/distribution/basic/c/c;

.field public a:Z

.field private b:Ljava/lang/String;

.field private c:Ljava/lang/String;

.field private d:Z

.field private e:Z

.field private f:Z

.field private g:Z

.field private h:Ljava/lang/String;

.field private i:Ljava/lang/String;

.field private j:Ljava/lang/String;

.field private k:Ljava/lang/String;

.field private l:I

.field private m:Z

.field private n:I

.field private o:Ljava/lang/String;

.field private p:Z

.field private q:Ljava/lang/String;

.field private r:Ljava/lang/String;

.field private s:I

.field private t:Ljava/lang/String;

.field private u:Ljava/lang/String;

.field private v:Ljava/lang/String;

.field private w:Ljava/lang/String;

.field private x:Z

.field private y:Z

.field private z:Z


# direct methods
.method public constructor <init>()V
    .locals 3

    const/4 v2, 0x1

    const/4 v1, 0x0

    const/4 v0, 0x0

    invoke-direct {p0}, Lcom/igexin/push/core/bean/BaseAction;-><init>()V

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->d:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->e:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->f:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->g:Z

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->h:Ljava/lang/String;

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->i:Ljava/lang/String;

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->j:Ljava/lang/String;

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->k:Ljava/lang/String;

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->l:I

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->m:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->a:Z

    iput v2, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->n:I

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->o:Ljava/lang/String;

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->p:Z

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->q:Ljava/lang/String;

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->r:Ljava/lang/String;

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->s:I

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->t:Ljava/lang/String;

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->u:Ljava/lang/String;

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->v:Ljava/lang/String;

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->w:Ljava/lang/String;

    iput-boolean v2, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->x:Z

    iput-boolean v2, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->y:Z

    iput-boolean v2, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->z:Z

    iput-boolean v2, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->A:Z

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->B:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->C:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->D:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->E:I

    return-void
.end method


# virtual methods
.method public A()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->z:Z

    return v0
.end method

.method public B()I
    .locals 1

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->D:I

    return v0
.end method

.method public C()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->m:Z

    return v0
.end method

.method public D()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->v:Ljava/lang/String;

    return-object v0
.end method

.method public E()Lcom/igexin/push/extension/distribution/basic/c/c;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->F:Lcom/igexin/push/extension/distribution/basic/c/c;

    return-object v0
.end method

.method public a()I
    .locals 1

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->n:I

    return v0
.end method

.method public a(I)V
    .locals 0

    iput p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->n:I

    return-void
.end method

.method public a(Lcom/igexin/push/extension/distribution/basic/c/c;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->F:Lcom/igexin/push/extension/distribution/basic/c/c;

    return-void
.end method

.method public a(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->o:Ljava/lang/String;

    return-void
.end method

.method public a(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->a:Z

    return-void
.end method

.method public b(I)V
    .locals 0

    iput p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->s:I

    return-void
.end method

.method public b(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->r:Ljava/lang/String;

    return-void
.end method

.method public b(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->p:Z

    return-void
.end method

.method public b()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->a:Z

    return v0
.end method

.method public c()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->o:Ljava/lang/String;

    return-object v0
.end method

.method public c(I)V
    .locals 0

    iput p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->E:I

    return-void
.end method

.method public c(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->w:Ljava/lang/String;

    return-void
.end method

.method public c(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->A:Z

    return-void
.end method

.method public d(I)V
    .locals 0

    iput p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->B:I

    return-void
.end method

.method public d(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->q:Ljava/lang/String;

    return-void
.end method

.method public d(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->d:Z

    return-void
.end method

.method public d()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->p:Z

    return v0
.end method

.method public e()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->r:Ljava/lang/String;

    return-object v0
.end method

.method public e(I)V
    .locals 0

    iput p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->C:I

    return-void
.end method

.method public e(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->b:Ljava/lang/String;

    return-void
.end method

.method public e(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->e:Z

    return-void
.end method

.method public f()I
    .locals 1

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->s:I

    return v0
.end method

.method public f(I)V
    .locals 0

    iput p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->l:I

    return-void
.end method

.method public f(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->c:Ljava/lang/String;

    return-void
.end method

.method public f(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->f:Z

    return-void
.end method

.method public g()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->w:Ljava/lang/String;

    return-object v0
.end method

.method public g(I)V
    .locals 0

    iput p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->D:I

    return-void
.end method

.method public g(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->h:Ljava/lang/String;

    return-void
.end method

.method public g(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->x:Z

    return-void
.end method

.method public h(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->i:Ljava/lang/String;

    return-void
.end method

.method public h(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->y:Z

    return-void
.end method

.method public h()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->A:Z

    return v0
.end method

.method public i()I
    .locals 1

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->E:I

    return v0
.end method

.method public i(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->j:Ljava/lang/String;

    return-void
.end method

.method public i(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->z:Z

    return-void
.end method

.method public j()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->q:Ljava/lang/String;

    return-object v0
.end method

.method public j(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->t:Ljava/lang/String;

    return-void
.end method

.method public j(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->m:Z

    return-void
.end method

.method public k()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->b:Ljava/lang/String;

    return-object v0
.end method

.method public k(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->u:Ljava/lang/String;

    return-void
.end method

.method public l()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->c:Ljava/lang/String;

    return-object v0
.end method

.method public l(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->k:Ljava/lang/String;

    return-void
.end method

.method public m(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->v:Ljava/lang/String;

    return-void
.end method

.method public m()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->d:Z

    return v0
.end method

.method public n()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->e:Z

    return v0
.end method

.method public o()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->f:Z

    return v0
.end method

.method public p()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->h:Ljava/lang/String;

    return-object v0
.end method

.method public q()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->i:Ljava/lang/String;

    return-object v0
.end method

.method public r()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->j:Ljava/lang/String;

    return-object v0
.end method

.method public s()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->t:Ljava/lang/String;

    return-object v0
.end method

.method public t()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->u:Ljava/lang/String;

    return-object v0
.end method

.method public u()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->x:Z

    return v0
.end method

.method public v()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->y:Z

    return v0
.end method

.method public w()I
    .locals 1

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->B:I

    return v0
.end method

.method public x()I
    .locals 1

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->C:I

    return v0
.end method

.method public y()I
    .locals 1

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->l:I

    return v0
.end method

.method public z()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/b/m;->k:Ljava/lang/String;

    return-object v0
.end method
